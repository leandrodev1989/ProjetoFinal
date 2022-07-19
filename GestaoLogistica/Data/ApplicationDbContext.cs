using GestaoLogistica.Models;
using GestaoLogistica.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoLogistica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<LogAuditoria> LogAuditorias { get; set; }
        public DbSet<Conferente> Conferentes { get; set; }
        public DbSet<ConferirCarga> ConferirCarga { get; set; }
        
       
    }
}