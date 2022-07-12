using GestaoLogistica.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    public class Fornecedor : Entity
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public TipoFornecedor  TipoFornecedor { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereço { get; set; }


        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public bool Ativo{ get; set; }

        /* EF Relation */

        public IEnumerable<Produto> Produtos { get; set; }
        
    }
}
