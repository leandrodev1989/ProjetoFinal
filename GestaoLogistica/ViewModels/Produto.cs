using DevIO.App.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoLogistica.Models
{
    public class Produto : Entity 
    {
        public Guid FornecedorId { get; set; }
       
       
       
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Nome Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(1000, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Qtd-Entrada")]
        public int Entrada { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Qtd-Saida")]
        public int Saida { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]    
        [DisplayName("Estoque")]
        public int  Estoque { get; set; }
       
        [Moeda]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Valor")]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Entrada")]
        public DateTime DataEntrada { get; set; }

        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public bool Ativo { get; set; }

        /* EF Relations */
        /// <summary>
        /// Relacionamneto 1 para Muitos
        /// </summary>
        public  Fornecedor Fornecedor { get; set; }


    
    }
}
