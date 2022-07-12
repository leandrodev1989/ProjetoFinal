using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoExpedicao.Models
{
    [Table("AbrirCarga")]
    public class AbrirCarga
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Docas")]
        public NumeroDoca NumeroDoca { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Hora Inicio")]
        public DateTime DatahoraInicio { get; set; }

        [Required(ErrorMessage = "o Campo {0}é Obrigatorio")]
        [MaxLength(20)]
        [DisplayName("Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "o Campo {0^é Obrigatorio")]
        [MaxLength(20)]
        [DisplayName("Tipo Veiculo")]
        public string TipoVeiculo { get; set; }


        [Required(ErrorMessage = "o Campo {0^é Obrigatorio")]
        [MaxLength(7)]
        [DisplayName("Placa")]
        public string Placa { get; set; }


        [ForeignKey("GuiId")]
        public int GuiId { get; set; }
        public  Conferencia Conferencia { get; set; }

    }

    public enum NumeroDoca
    {
        Doca1 = 1,
        Doca2 = 2,
        Doca3 = 3,
        Doca4 = 4,
        Doca5 = 5,
        Doca6 = 6,
        Doca7 = 7,
        Doca8 = 8,
        Doca9 = 9,
        Doca10 = 10
    }
}
