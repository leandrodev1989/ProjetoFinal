using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    [Table("LogAuditoria")]
    public class LogAuditoria : Entity
    {
    
        public Guid ConferenteId { get; set; }

        
        [DisplayName ("Detalhes Auditoria")]
        public string DetalhesAuditoria { get; set; }

       
        [DisplayName ("Email Usuario")]
        public string EmailUsuario { get; set; }

        /* Relation */
        public Conferente Conferente { get; set; }      

    }
}
