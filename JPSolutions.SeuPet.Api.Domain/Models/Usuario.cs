using System;
using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class Usuario : Entity
    {
        public Usuario()
        {
            EnderecoUsuario = new HashSet<EnderecoUsuario>();
            Pet = new HashSet<Pet>();
            SessaoUsuario = new HashSet<SessaoUsuario>();
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmada { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long? TelefoneCelular { get; set; }
        public string Documento { get; set; }

        public virtual ICollection<EnderecoUsuario> EnderecoUsuario { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
        public virtual ICollection<SessaoUsuario> SessaoUsuario { get; set; }
    }
}
