using AutoMapper;
using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Interfaces.ICommandResult;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Domain.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Service.Services
{
    public class UsuarioService : BaseService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        
        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IMapper mapper,
                              INotificador notificador) : base(notificador)
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        }

        public async Task<ICommandResult> CadastrarAsync(UsuarioViewModel usuarioViewModels)
        {
            var usuarios = await this._usuarioRepository.ObterAsync(x => x.Email == usuarioViewModels.Email);
            if (usuarios.Any())
            {
                Notificar("O Email fornecido já está em uso por outro usuário.");
                return CommandResultError();
            }
            var usuario = _mapper.Map<Usuario>(usuarioViewModels);
            await this._usuarioRepository.AdicionarAsync(usuario);
            return CommandResultSucess(_mapper.Map<UsuarioViewModel>(usuario));
        }

        public async Task<ICommandResult> LoginAsync(LoginUserViewModel loginUserViewModel)
        {
            var usuario = await this._usuarioRepository.ObterAsync(x => x.Email == loginUserViewModel.Email && x.Senha == loginUserViewModel.Senha);
            if (!usuario.Any())
            {
                Notificar("Email ou Senha inválido");
                return CommandResultError();
            }
            return CommandResultSucess(_mapper.Map<UsuarioViewModel>(usuario.FirstOrDefault()));
        }
    }
}
