using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class TagPet : Entity
    {
        public TagPet()
        {
            PetXTagPet = new HashSet<PetXTagPet>();
        }

        public string NomeTag { get; set; }

        public virtual ICollection<PetXTagPet> PetXTagPet { get; set; }
    }
}
