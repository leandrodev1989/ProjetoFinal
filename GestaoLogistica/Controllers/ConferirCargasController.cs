﻿using GestaoLogistica.Data;
using GestaoLogistica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestaoLogistica.Controllers
{
    [Authorize]
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
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Nome");
           
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConferirCarga conferirCarga)
        {
           
            float altura1 = 0.90f, comprimento1 = 0.70f, profundidade1 = 0.90f;
            float altura2 = 0.50f, comprimento2 = 0.50f, profundidade2 = 0.50f;
            float altura3 = 0.40f, comprimento3 = 0.40f, profundidade3 = 0.30f;
            if (conferirCarga.TipoProduto.Equals(TipoProduto.Geladeira))
            {
               
                float convert1 = ((float)altura1 * comprimento1 * profundidade1);
                conferirCarga.Cubagem = Convert.ToInt32(conferirCarga.QtdCaixas * (altura1 * comprimento1* profundidade1));

              

            }
            else if (conferirCarga.TipoProduto.Equals(TipoProduto.Fogao))
            {
                float convert2 = ((float)altura2 * comprimento2 * profundidade2);
                conferirCarga.Cubagem = Convert.ToInt32(conferirCarga.QtdCaixas * (altura2 * comprimento2 * profundidade2));
            
            }
            else if(conferirCarga.TipoProduto.Equals(TipoProduto.Microondas))
            {
                float convert3 = ((float)altura3 * comprimento3 * profundidade3);
                conferirCarga.Cubagem = Convert.ToInt32(conferirCarga.QtdCaixas * (altura3 * comprimento3 * profundidade3));            
            }
            _context.Add(conferirCarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            conferirCarga.Id = Guid.NewGuid();
             
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Nome", conferirCarga.ConferenteId);
           
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
            ViewData["ConferenteId"] = new SelectList(_context.Conferentes, "Id", "Nome", conferirCarga.ConferenteId);
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
