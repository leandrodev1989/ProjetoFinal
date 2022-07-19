using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    public class Conferente : Entity
    {
        
       

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(11, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
        [DisplayName("Cpf")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O {0} Digitado é Inválido")]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ")]
        [DisplayName("Turno")]
        public string Turno { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(30, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 6)]
        [DisplayName("Setor")]
        public string Setor { get; set; }

        /* EF Relation */
        /// <summary>
        /// Relacionamento 1 para Muitos Com Produtos
        /// </summary>
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
