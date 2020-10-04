using System.ComponentModel.DataAnnotations;

namespace JPSolutions.SeuPet.Api.Domain.ViewModels
{
    public class PetViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public bool IsVenda { get; set; }

        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public long CategoriaPetId { get; set; }

        public long? UsuarioId { get; set; }
    }
}
