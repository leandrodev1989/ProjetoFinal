using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoLogistica.Models
{
    public class Produto : Entity
    {
        [Key]
        public Guid FornecedorId { get; set; }

      
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(30, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Nome")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Valor")]
        public float Valor { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.DateTime)]
        [DisplayName("Data Cadastro")]
        public DateTime Datacadastro { get; set; }

        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        public bool Ativo { get; set; }


        
    }
}
