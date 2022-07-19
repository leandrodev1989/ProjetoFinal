using GestaoLogistica.Data;
using GestaoLogistica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoLogistica.Controllers
{
    /// <summary>
    /// Authorize para limitar  a acesso do usuario
    /// </summary>
    [Authorize]
    public class ConferentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferentesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
              return _context.Conferentes != null ? 
                          View(await _context.Conferentes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Conferentes'  is null.");
        }


        /// <summary>
        /// Metodo Get para Mostrar  os Detalhes dos conferentes cadastrados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Conferentes == null)
            {
                return NotFound();
            }

            var conferente = await _context.Conferentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferente == null)
            {
                return NotFound();
            }

            return View(conferente);
        }

       
        /// <summary>
        /// Get do Creat
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

      

        /// <summary>
        /// Metodo Post para Criação do Cadastro do USUARIO
        /// </summary>
        /// <param name="conferente"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Conferente conferente)
        {


            conferente.Id = Guid.NewGuid();
                _context.Add(conferente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
                return View(conferente);
        }

        
        /// <summary>
        /// Metodo Get para Pegar o usuario pelo id e fazer a edição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Conferentes == null)
            {
                return NotFound();
            }

            var conferente = await _context.Conferentes.FindAsync(id);
            if (conferente == null)
            {
                return NotFound();
            }
            return View(conferente);
        }

        

        /// <summary>
        /// Metodo Post para fazer   edição do usuario cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conferente"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Conferente conferente)
        {
            if (id != conferente.Id)
            {
                return NotFound();
            }         

                try
                {
                    _context.Update(conferente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenteExists(conferente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
                        
                return View(conferente);
            
                    
        }

        /// <summary>
        /// Metodo  Get para Editar o usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Conferentes == null)
            {
                return NotFound();
            }

            var conferente = await _context.Conferentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferente == null)
            {
                return NotFound();
            }

            return View(conferente);
        }

        
        /// <summary>
        /// Metodo Post para Verificar se o usuario Existe pelo a Id e confirmar a deleção
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Conferentes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conferentes'  is null.");
            }
            var conferente = await _context.Conferentes.FindAsync(id);
            if (conferente != null)
            {
                _context.Conferentes.Remove(conferente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// Booleano para verificar o usuario existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ConferenteExists(Guid id)
        {
          return (_context.Conferentes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
