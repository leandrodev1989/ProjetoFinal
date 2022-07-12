using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoExpedicao.Models
{
    [Table("Conferencia")]
    public class Conferencia
    {
        [Key]
        [Display(Name = "Codigo")]
        public int ConferenciaId { get; set; }

        [ForeignKey("GuiId")]
        public Guid GuidId { get; set; }

        


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Hora")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Quantidade de Caixas")]
        public int QtdCaixas { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Cubagem")]
        public float Cubagem { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Status Conferência")]
        public string StatusConferencia { get; set; }

        public ICollection<Conferente> conferentes { get; set; } = new List<Conferente>();





       

    }

   

}
