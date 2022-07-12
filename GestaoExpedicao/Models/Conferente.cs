using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoExpedicao.Models
{
    [Table("Conferente")]
    public class Conferente
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }



        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [MaxLength(30, ErrorMessage = "O Número de Caracteres tem que ser Menor")]
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
        [StringLength(10)]
        [DisplayName("Turno")]
        public string Turno { get; set; }


        [Required(ErrorMessage = "O Campo {0} é Obrigátorio")]
        [DisplayName("Setor")]
        public string Setor { get; set; }

        public ICollection<Conferencia> conferencias { get; set; } = new HashSet<Conferencia>();


    }

}
