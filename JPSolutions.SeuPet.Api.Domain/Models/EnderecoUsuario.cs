namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class EnderecoUsuario : Entity
    {
        public string Rua { get; set; }
        public long Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public long UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
