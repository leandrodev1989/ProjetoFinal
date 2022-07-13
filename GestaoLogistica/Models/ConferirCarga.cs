using GestaoLogistica.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    public class ConferirCarga : Entity
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Tipo Operação")]
        public string TipoOperacao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(20, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Placa")]
        public string Placa { get; set ; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Hora inicio")]
        public DateTime Datahora { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(20, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Transportadora")]
        public string Trasnportadora { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Doca")]
        public int Doca { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Qtd Caixas")]
        public int QtdCaixas { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Cubagem")]
        public int Cubagem { get; set; }

       
        public ICollection<Conferente> Conferentes { get; set; } = new HashSet<Conferente>();

    }
}
