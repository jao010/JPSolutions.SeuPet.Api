namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class PetXTagPet : Entity
    {
        public long PetId { get; set; }
        public long TagPetId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual TagPet TagPet { get; set; }
    }
}
