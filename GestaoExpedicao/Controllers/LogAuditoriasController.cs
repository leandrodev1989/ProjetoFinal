using GestaoExpedicao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoExpedicao.Controllers
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

    }
}
