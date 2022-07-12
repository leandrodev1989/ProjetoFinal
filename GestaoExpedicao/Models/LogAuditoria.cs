using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoExpedicao.Models
{
    [Table("LogAuditoria")]
    public class LogAuditoria
    {

        [Key]
        [Column("Id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Column("DetalhesAuditoria")]
        [Display(Name = "DetalhesAuditoria")]
        public string DetalhesAuditoria { get; set; }

        [ForeignKey("EmailUsuario")]
        public string EmailUsuario { get; set; }
        public Conferente Conferente { get; set; }

    }
}
