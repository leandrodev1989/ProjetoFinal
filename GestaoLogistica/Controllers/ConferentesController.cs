using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoLogistica.Data;
using GestaoLogistica.Models;

namespace GestaoLogistica.Controllers
{
    public class ConferentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conferentes
        public async Task<IActionResult> Index()
        {
              return _context.Conferentes != null ? 
                          View(await _context.Conferentes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Conferentes'  is null.");
        }

        // GET: Conferentes/Details/5
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

        // GET: Conferentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conferentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Email,Turno,Setor")] Conferente conferente)
        {
            if (ModelState.IsValid)
            {
                conferente.Id = Guid.NewGuid();
                _context.Add(conferente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferente);
        }

        // GET: Conferentes/Edit/5
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

        // POST: Conferentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Cpf,Email,Turno,Setor")] Conferente conferente)
        {
            if (id != conferente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            }
            return View(conferente);
        }

        // GET: Conferentes/Delete/5
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

        // POST: Conferentes/Delete/5
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

        private bool ConferenteExists(Guid id)
        {
          return (_context.Conferentes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
