namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class FotosPet : Entity
    {
        public byte[] Foto { get; set; }
        public string Descricao { get; set; }
        public long PetId { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
