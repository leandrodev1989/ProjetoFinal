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
    public class LogAuditoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogAuditoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LogAuditorias
        public async Task<IActionResult> Index()
        {
              return _context.LogAuditorias != null ? 
                          View(await _context.LogAuditorias.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LogAuditorias'  is null.");
        }

        // GET: LogAuditorias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.LogAuditorias == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logAuditoria == null)
            {
                return NotFound();
            }

            return View(logAuditoria);
        }

        // GET: LogAuditorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogAuditorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DetalhesAuditoria,EmailUsuario")] LogAuditoria logAuditoria)
        {
            if (ModelState.IsValid)
            {
                logAuditoria.Id = Guid.NewGuid();
                _context.Add(logAuditoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logAuditoria);
        }

        // GET: LogAuditorias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.LogAuditorias == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditorias.FindAsync(id);
            if (logAuditoria == null)
            {
                return NotFound();
            }
            return View(logAuditoria);
        }

        // POST: LogAuditorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DetalhesAuditoria,EmailUsuario")] LogAuditoria logAuditoria)
        {
            if (id != logAuditoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logAuditoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogAuditoriaExists(logAuditoria.Id))
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
            return View(logAuditoria);
        }

        // GET: LogAuditorias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.LogAuditorias == null)
            {
                return NotFound();
            }

            var logAuditoria = await _context.LogAuditorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logAuditoria == null)
            {
                return NotFound();
            }

            return View(logAuditoria);
        }

        // POST: LogAuditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.LogAuditorias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LogAuditorias'  is null.");
            }
            var logAuditoria = await _context.LogAuditorias.FindAsync(id);
            if (logAuditoria != null)
            {
                _context.LogAuditorias.Remove(logAuditoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogAuditoriaExists(Guid id)
        {
          return (_context.LogAuditorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
