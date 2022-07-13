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
              return _context.ConferirCarga != null ? 
                          View(await _context.ConferirCarga.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ConferirCarga'  is null.");
        }

        // GET: ConferirCargas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConferirCarga == null)
            {
                return NotFound();
            }

            var conferirCarga = await _context.ConferirCarga
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
            return View();
        }

        // POST: ConferirCargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoOperacao,Placa,Datahora,Trasnportadora,Doca,QtdCaixas,Cubagem")] ConferirCarga conferirCarga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conferirCarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferirCarga);
        }

        // GET: ConferirCargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(conferirCarga);
        }

        // POST: ConferirCargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoOperacao,Placa,Datahora,Trasnportadora,Doca,QtdCaixas,Cubagem")] ConferirCarga conferirCarga)
        {
            if (id != conferirCarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            }
            return View(conferirCarga);
        }

        // GET: ConferirCargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConferirCarga == null)
            {
                return NotFound();
            }

            var conferirCarga = await _context.ConferirCarga
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool ConferirCargaExists(int id)
        {
          return (_context.ConferirCarga?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
