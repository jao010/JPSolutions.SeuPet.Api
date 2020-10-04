using AutoMapper;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Domain.ViewModels;

namespace JPSolutions.SeuPet.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pet, PetViewModel>().ReverseMap();
            CreateMap<CategoriaPet, CategoriaPetViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
