using GestaoLogistica.Data;
using GestaoLogistica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoLogistica.Controllers
{
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

       
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Conferente conferente)
        {
           
            
                conferente.Id = Guid.NewGuid();
                _context.Add(conferente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
                return View(conferente);
        }

      
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
