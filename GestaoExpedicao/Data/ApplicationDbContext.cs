using GestaoExpedicao.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoExpedicao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AbrirCarga> AbrirCargas { get; set; }
        public DbSet<Conferencia> Conferencias { get; set; }
        public DbSet<Conferente> Conferentes { get; set; }
        public DbSet<LogAuditoria> LogAuditorias { get; set; }
       
        
       
       
    }
}