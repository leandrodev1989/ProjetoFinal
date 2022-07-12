using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoLogistica.Models
{
    public class Endereco : Entity
    {
        public Guid FornecedorId { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(100, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Numero")]
        public string Numero { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }




        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(8, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Descrição")]
        public string  Cep { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Bairro")]
        public string  Bairro { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(20, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Cidade")]
        public string  Cidade{ get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(50, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Descrição")]
        public string  Estado { get; set; }

        /* EF Relation */
        //1 para 1
        
        public Fornecedor Fornecedor { get; set; }
    }
}
