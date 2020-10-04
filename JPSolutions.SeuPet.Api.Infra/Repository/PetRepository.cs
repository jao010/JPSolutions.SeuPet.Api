using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Infra.Contexts;

namespace JPSolutions.SeuPet.Api.Infra.Repository
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(SeuPetContext seuPetContext) : base(seuPetContext) { }
    }
}
