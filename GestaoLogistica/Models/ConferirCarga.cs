using GestaoLogistica.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    public class ConferirCarga : Entity
    {     
        public Guid ConferenteId { get; set; }   

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Tipo Operação")]
        public TipoOperacao TipoOperacao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(7, ErrorMessage = "O Campo {0} precisa ter 7 Caracteres ")]
        [DisplayName("Placa")]
        public string Placa { get; set ; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Hora inicio")]
        public DateTime Datahora { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter no Maximo {1} Caracteres ")]
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

        /* Relation */
        /// <summary>
        /// Relacionamento 1 para Muitos
        /// </summary>
        public Conferente Conferente { get; set; }


    }


    public enum TipoOperacao
    {
        Expedicao = 1,
        Recebimento
    }
}
