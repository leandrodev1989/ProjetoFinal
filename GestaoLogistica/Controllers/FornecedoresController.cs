using GestaoLogistica.Data;
using GestaoLogistica.Models;
using GestaoLogistica.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoLogistica.Controllers
{
    /// <summary>
    /// Usando o Identity para o usuario só acessar a aplicação se logado
    /// </summary>
    [Authorize]
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FornecedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Fornecedores
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return _context.Fornecedores != null ? 
                          View(await _context.Fornecedores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Fornecedores'  is null.");
        }

        /// <summary>
        ///  GET: Fornecedores Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        /// <summary>
        ///  GET: Fornecedores para a criação de um novo
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///  POST: Fornecedores/Create para Criar e cadastrar  um novno fornecedor    
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
           
            
                fornecedor.Id = Guid.NewGuid();
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();

            _context.LogAuditorias.Add(
         new LogAuditoria
         {
             EmailUsuario = User.Identity.Name,
             DetalhesAuditoria = String.Concat("Realizou o Cadastro do Fornecedor : ",
             fornecedor.Nome, " Data do Cadastro : ", DateTime.Now.ToLongDateString())


         });
            return RedirectToAction(nameof(Index));
            
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        /// <summary>
        ///  POST: Fornecedores/Edit para Criar e atualizar  um novno fornecedor    
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns> 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }
         
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                _context.LogAuditorias.Add(
               new LogAuditoria
               {
                   EmailUsuario = User.Identity.Name,
                   DetalhesAuditoria = String.Concat("Atualizou o Fornecedor de nome  : ",
                   fornecedor.Nome, " Data de Atualização : ", DateTime.Now.ToLongDateString())

               });
                _context.SaveChanges();
            }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        /// <summary>
        ///  POST: Fornecedores/Delet para Criar Excluir  um fornecedor    
        /// </summary>
        /// <param name="fornecedor"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Fornecedores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fornecedores'  is null.");
            }
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
            }
            new LogAuditoria
            {   ///Registrando o Usuario no momento que ele deleta o carregamento
                EmailUsuario = User.Identity.Name,
                DetalhesAuditoria = String.Concat("Deletou o Carregamento de placa : ",
                     fornecedor.Nome, " Data de Exclusão : ", DateTime.Now.ToLongDateString())

            };
            _context.SaveChanges();
            await _context.SaveChangesAsync();
           

            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(Guid id)
        {
          return (_context.Fornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
