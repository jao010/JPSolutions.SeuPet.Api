using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Infra.Contexts;

namespace JPSolutions.SeuPet.Api.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SeuPetContext seuPetContext) : base(seuPetContext) { }
    }
}
