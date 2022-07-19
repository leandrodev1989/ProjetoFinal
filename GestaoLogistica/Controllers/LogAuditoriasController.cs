using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoLogistica.Data;
using GestaoLogistica.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GestaoLogistica.Controllers
{
    /// <summary>
    /// Controler Principal do Log de Auditoria
    /// </summary>
    [Authorize]
    public class LogAuditoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogAuditoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista as Atividades Realizadas do usuario logado na aplicação
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return _context.LogAuditorias != null ? 
                          View(await _context.LogAuditorias.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LogAuditorias'  is null.");
        }

    }
}
