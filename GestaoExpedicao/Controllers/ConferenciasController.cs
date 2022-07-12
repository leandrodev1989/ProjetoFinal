using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoExpedicao.Data;
using GestaoExpedicao.Models;

namespace GestaoExpedicao.Controllers
{
    public class ConferenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conferencias
        public async Task<IActionResult> Index()
        {
              return _context.Conferencias != null ? 
                          View(await _context.Conferencias.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Conferencias'  is null.");
        }

        // GET: Conferencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conferencias == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencias
                .FirstOrDefaultAsync(m => m.ConferenciaId == id);
            if (conferencia == null)
            {
                return NotFound();
            }

            return View(conferencia);
        }

        // GET: Conferencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conferencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConferenciaId,GuidId,DataHora,QtdCaixas,Cubagem,StatusConferencia")] Conferencia conferencia)
        {

           
           

            if (ModelState.IsValid)
            {
                
                _context.Add(conferencia);

               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferencia);
        }


        // GET: Conferencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conferencias == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencias.FindAsync(id);
            if (conferencia == null)
            {
                return NotFound();
            }
            return View(conferencia);
        }

        // POST: Conferencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConferenciaId,GuidId,DataHora,QtdCaixas,Cubagem,StatusConferencia")] Conferencia conferencia)
        {
            if (id != conferencia.ConferenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenciaExists(conferencia.ConferenciaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(conferencia);
        }

        // GET: Conferencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conferencias == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencias
                .FirstOrDefaultAsync(m => m.ConferenciaId == id);
            if (conferencia == null)
            {
                return NotFound();
            }

            return View(conferencia);
        }

        // POST: Conferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conferencias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conferencias'  is null.");
            }
            var conferencia = await _context.Conferencias.FindAsync(id);
            if (conferencia != null)
            {
                _context.Conferencias.Remove(conferencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConferenciaExists(int id)
        {
          return (_context.Conferencias?.Any(e => e.ConferenciaId == id)).GetValueOrDefault();
        }
    }
}
