using System;

namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class SessaoUsuario : Entity
    {
        public string Token { get; set; }
        public DateTime DataGeracao { get; set; }
        public DateTime DataLimite { get; set; }
        public int LimiteExpiracaoMin { get; set; }
        public long UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
