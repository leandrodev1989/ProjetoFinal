using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    [Table("LogAuditoria")]
    public class LogAuditoria : Entity
    {


        [Key]
        public int Id { get; set; }

        [Column("DetalhesAuditoria")]
        [Display(Name = "Detalhes Auditoria")]
        public string DetalhesAuditoria { get; set; }

        [ForeignKey("EmailUsuario")]
        [Display(Name = "Email Usuario")]
        public string EmailUsuario { get; set; }
        public Conferente Conferente { get; set; }
    }
}
