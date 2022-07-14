using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoLogistica.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
      

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(1000, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]    
        [DisplayName("Estoque")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        public int  Estoque { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Cadastro")]
        public DateTime Datacadastro { get; set; }

        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public bool Ativo { get; set; }

        /* EF Relations */
        /// <summary>
        /// Relacionamneto 1 para Muitos
        /// </summary>
        public Fornecedor Fornecedor { get; set; }

        
    }
}
