using GestaoLogistica.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.ViewModels
{
   
    public class LogAuditoria : Entity
    {
       

        [Column("DetalhesAuditoria")]
        [Display(Name = "Detalhes Auditoria")]
        public string DetalhesAuditoria { get; set; }



        [Column("Email Usuario")]
        [Display(Name = "EmailUsuario")]
        public string EmailUsuario { get; set; }
    }
}

