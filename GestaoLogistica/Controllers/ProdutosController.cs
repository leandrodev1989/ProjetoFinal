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

            _context.LogAuditorias.Add(
         new LogAuditoria
         {
             EmailUsuario = User.Identity.Name,
             DetalhesAuditoria = "Entro na Tela de Listagem do Produto: "

         });


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
            _context.SaveChangesAsync();
        return View(produto);
    }

    // GET: Produtos/Create
    public IActionResult Create()
    {

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Documento");
        return View();
    }

    // POST: Produtos/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Produto produto)
    {




        produto.Id = Guid.NewGuid();
        _context.Add(produto);

            _context.LogAuditorias.Add(
           new LogAuditoria
           {
               EmailUsuario = User.Identity.Name,
               DetalhesAuditoria = String.Concat("Cadastrou o Produto: ",
               produto.Nome, " Data de Cadastro : ", DateTime.Now.ToLongDateString())
               

           });

            await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

        ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Documento", produto.FornecedorId);
        return View(produto);
    }

    // GET: Produtos/Edit/5
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


            _context.LogAuditorias.Add(
         new LogAuditoria
         {
             EmailUsuario = User.Identity.Name,
             DetalhesAuditoria = String.Concat("Entro na Tela de Edição do Produto: ",
             produto.Id, " - ", produto.Nome)


         });

            _context.SaveChangesAsync();
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Documento", produto.FornecedorId);
        return View(produto);
    }



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

        ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Documento", produto.FornecedorId);
        return View(produto);
    }

    // GET: Produtos/Delete/5
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

    // POST: Produtos/Delete/5
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
          {
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
