using JPSolutions.SeuPet.Api.Utils.DataAnnotationsCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPSolutions.SeuPet.Api.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo {0} está no formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string SenhaConfirmada { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} é inválido")]
        public DateTime DataNascimento { get; set; }

        public long? TelefoneCelular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DocumentoValidation(ErrorMessage = "O campo {0} é inválido")]
        public string Documento { get; set; }
    }
}
