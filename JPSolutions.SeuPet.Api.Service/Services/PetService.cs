using AutoMapper;
using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Interfaces.ICommandResult;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Domain.ViewModels;
using JPSolutions.SeuPet.Api.Service.Services;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Service
{
    public class PetService : BaseService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public PetService(IPetRepository petRepository,
                          IMapper mapper,
                          INotificador notificador) : base(notificador)
        {
            this._petRepository = petRepository;
            this._mapper = mapper;
        }

        public async Task<ICommandResult> CadastrarAsync(PetViewModel petViewModel)
        {
            if (petViewModel.IsVenda && petViewModel.Valor == null)
            {
                Notificar("Foi indicado que o Pet vai conter um valor mas ele não foi inserido.");
                return CommandResultError();
            }

            if (petViewModel.UsuarioId == null)
            {
                Notificar("Ocorreu algum erro. Tente novamente");
                return CommandResultError();
            }

            var pet = _mapper.Map<Pet>(petViewModel);
            await this._petRepository.AdicionarAsync(pet);
            petViewModel.Id = pet.Id;
            return CommandResultSucess(petViewModel);
            
        }
    }
}
