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
    public class AbrirCargasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbrirCargasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AbrirCargas
        public async Task<IActionResult> Index()
        {
              return _context.AbrirCargas != null ? 
                          View(await _context.AbrirCargas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AbrirCargas'  is null.");
        }

        // GET: AbrirCargas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AbrirCargas == null)
            {
                return NotFound();
            }

            var abrirCarga = await _context.AbrirCargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abrirCarga == null)
            {
                return NotFound();
            }

            return View(abrirCarga);
        }

        // GET: AbrirCargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbrirCargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroDoca,DatahoraInicio,Nome,Veiculo,Placas,GuiId")] AbrirCarga abrirCarga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abrirCarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abrirCarga);
        }

        // GET: AbrirCargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AbrirCargas == null)
            {
                return NotFound();
            }

            var abrirCarga = await _context.AbrirCargas.FindAsync(id);
            if (abrirCarga == null)
            {
                return NotFound();
            }
            return View(abrirCarga);
        }

        // POST: AbrirCargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroDoca,DatahoraInicio,Nome,Veiculo,Placas,GuiId")] AbrirCarga abrirCarga)
        {
            if (id != abrirCarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abrirCarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbrirCargaExists(abrirCarga.Id))
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
            return View(abrirCarga);
        }

        // GET: AbrirCargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AbrirCargas == null)
            {
                return NotFound();
            }

            var abrirCarga = await _context.AbrirCargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abrirCarga == null)
            {
                return NotFound();
            }

            return View(abrirCarga);
        }

        // POST: AbrirCargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AbrirCargas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AbrirCargas'  is null.");
            }
            var abrirCarga = await _context.AbrirCargas.FindAsync(id);
            if (abrirCarga != null)
            {
                _context.AbrirCargas.Remove(abrirCarga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbrirCargaExists(int id)
        {
          return (_context.AbrirCargas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
