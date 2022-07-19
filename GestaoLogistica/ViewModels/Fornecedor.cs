
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestaoLogistica.Models
{
    public class Fornecedor : Entity
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(14, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public TipoFornecedor  TipoFornecedor { get; set; }


        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public bool Ativo{ get; set; }

        
        /* EF Relation */
        /// <summary>
        /// Relacionamento 1 para Muitos Com Produtos
        /// </summary>
        public  IEnumerable<Produto> Produtos { get; set; }
        public  IEnumerable<Conferente> Conferentes { get; set; }
        
    }



    public enum TipoFornecedor : int
    {
        PessoaFisica = 1,
        PessoaJuridica
    }
}
