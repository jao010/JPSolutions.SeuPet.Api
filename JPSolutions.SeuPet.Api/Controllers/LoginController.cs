using JPSolutions.SeuPet.Api.Domain.Interfaces.ICommandResult;
using JPSolutions.SeuPet.Api.Domain.Models.CommandResult;
using JPSolutions.SeuPet.Api.Domain.ViewModels;
using JPSolutions.SeuPet.Api.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly GerarJwtService _gerarJwtService;

        public LoginController(UsuarioService usuarioService,
                               GerarJwtService gerarJwtService)
        {
            this._usuarioService = usuarioService;
            this._gerarJwtService = gerarJwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var commandResult = await this._usuarioService.LoginAsync(loginUserViewModel);
            if (commandResult.IsSucess)
                return await GerarJwt(commandResult);

            return BadRequest(commandResult);
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(UsuarioViewModel usuarioViewModels)
        {
            if (!ModelState.IsValid) return BadRequest();

            var commandResult = await this._usuarioService.CadastrarAsync(usuarioViewModels);
            if (commandResult.IsSucess)
                return await GerarJwt(commandResult);

            return BadRequest(commandResult);
        }

        private async Task<IActionResult> GerarJwt(ICommandResult commandResult)
        {
            var result = (CommandResult<UsuarioViewModel>)commandResult;
            return Ok(await this._gerarJwtService.GerarJwtAsync(result.Data.Email));
        }
    }
}
