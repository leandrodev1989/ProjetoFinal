using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoLogistica.Data;
using GestaoLogistica.Models;
using GestaoLogistica.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GestaoLogistica.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {

         //   _context.LogAuditorias.Add(
         //new LogAuditoria
         //{
         //    EmailUsuario = User.Identity.Name,
         //    DetalhesAuditoria = "Entro na Tela de Listagem do Produto: "

         //});


            var applicationDbContext = _context.Produtos.Include(p => p.Fornecedor);
            _context.SaveChanges();

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }


            _context.LogAuditorias.Add(
         new LogAuditoria
         {
             EmailUsuario = User.Identity.Name,
             DetalhesAuditoria = String.Concat("Entro na Tela de Detalhes do Produto: ",
             produto.Id, " - ", produto.Nome)


         });
            _ = _context.SaveChangesAsync();
            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            return View();
        }


        /// <summary>
        /// Metodo de Criação e Cadastro de produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
         
                produto.Id = Guid.NewGuid();
                _context.Add(produto);
                ///Executando entrada no Estoque no hora do Cadastro
                produto.Estoque = produto.Entrada += produto.Estoque;


              ///Iniciando o Log de Auditoria para Retornar o Usuario que fez o cadastro de determinado PRODUTO E HORARIO
                _context.LogAuditorias.Add(
               new LogAuditoria
               {
                   EmailUsuario = User.Identity.Name,
                   DetalhesAuditoria = String.Concat("Cadastrou o Produto: ",
                   produto.Nome, " Data de Cadastro : ", DateTime.Now.ToLongDateString())


               });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome", produto.FornecedorId);
            
            
          
            return View(produto);
        }



        // GET: Produto
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            ///Registro No Log  no momento que usuario entra na index de edição do produto
            _context.LogAuditorias.Add(
         new LogAuditoria
         {
             EmailUsuario = User.Identity.Name,
             DetalhesAuditoria = String.Concat("Entro na Tela de Edição do Produto: ",
             produto.Id, " - ", produto.Nome)


         });

            await _context.SaveChangesAsync().ConfigureAwait(false);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome", produto.FornecedorId);
            return View(produto);
        }


        /// <summary>
        /// Metodo Post para editar o produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }



            try
            {

                _context.Update(produto);
                await _context.SaveChangesAsync();
                ///Registrando O Momento que usuario atualiza o produto e data
                _context.LogAuditorias.Add(
                  new LogAuditoria
                  {
                      EmailUsuario = User.Identity.Name,
                      DetalhesAuditoria = String.Concat("Atualizou o Produto: ",
                      produto.Nome, " Data de Atualização : ", DateTime.Now.ToLongDateString())

                  });
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        /// <summary>
        /// POST: Produtos para Confirmar a exclusão do produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditorias.Add(
          new LogAuditoria
          {   ///Registrando o Usuario no momento que ele deleta o produto
              EmailUsuario = User.Identity.Name,
              DetalhesAuditoria = String.Concat("Deletou o Produto: ",
              produto.Nome, " Data de Exclusão : ", DateTime.Now.ToLongDateString())

          });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
