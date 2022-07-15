using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLogistica.Models
{
    [Table("Endereco")]
    public class Endereco : Entity
    {

      
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Numero")]
        public string Numero { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }




        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(11, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Cep")]
        public string Cep { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        public string Bairro { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre ", MinimumLength = 2)]
        [DisplayName("Estado")]
        public string Estado { get; set; }


        /* EF Relation */
        /// <summary>
        /// Relacionamneto 1 para 1
        /// </summary>
        public Fornecedor Fornecedor { get; set; }
    }
}
