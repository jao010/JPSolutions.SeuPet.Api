using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class CategoriaPet : Entity
    {
        public CategoriaPet()
        {
            Pet = new HashSet<Pet>();
        }

        public string NomeCategoria { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
