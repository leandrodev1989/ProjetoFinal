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
    public class ConferirCargasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConferirCargasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConferirCargas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConferirCarga.Include(c => c.Conferente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConferirCargas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ConferirCarga == null)
            {
                return NotFound();
            }

            var conferirCarga = await _context.ConferirCarga
                .Include(c => c.Conferente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferirCarga == null)
            {
                return NotFound();
            }

            return View(conferirCarga);
        }

        // GET: ConferirCargas/Create
        public IActionResult Create()
        {
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Cpf");
            return View();
        }

        // POST: ConferirCargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ConferirCarga conferirCarga)
        {
          
            
                conferirCarga.Id = Guid.NewGuid();
                _context.Add(conferirCarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Cpf", conferirCarga.ConferenteId);
            return View(conferirCarga);
        }

        // GET: ConferirCargas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ConferirCarga == null)
            {
                return NotFound();
            }

            var conferirCarga = await _context.ConferirCarga.FindAsync(id);
            if (conferirCarga == null)
            {
                return NotFound();
            }
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Cpf", conferirCarga.ConferenteId);
            return View(conferirCarga);
        }

        // POST: ConferirCargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ConferirCarga conferirCarga)
        {
            if (id != conferirCarga.Id)
            {
                return NotFound();
            }

           
            
                try
                {
                    _context.Update(conferirCarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferirCargaExists(conferirCarga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Cpf", conferirCarga.ConferenteId);
            return View(conferirCarga);
        }

        // GET: ConferirCargas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ConferirCarga == null)
            {
                return NotFound();
            }

            var conferirCarga = await _context.ConferirCarga
                .Include(c => c.Conferente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferirCarga == null)
            {
                return NotFound();
            }

            return View(conferirCarga);
        }

        // POST: ConferirCargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ConferirCarga == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ConferirCarga'  is null.");
            }
            var conferirCarga = await _context.ConferirCarga.FindAsync(id);
            if (conferirCarga != null)
            {
                _context.ConferirCarga.Remove(conferirCarga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConferirCargaExists(Guid id)
        {
          return (_context.ConferirCarga?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
