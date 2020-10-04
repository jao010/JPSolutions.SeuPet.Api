using AutoMapper;
using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models.CommandResult;
using JPSolutions.SeuPet.Api.Domain.ViewModels;
using JPSolutions.SeuPet.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly ICategoriaPetRepository _categoriaPetRepository;
        private readonly PetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository,
                             ICategoriaPetRepository categoriaPetRepository,
                             PetService petService,
                             IMapper mapper)
        {
            this._petRepository = petRepository;
            this._categoriaPetRepository = categoriaPetRepository;
            this._petService = petService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Obter() => Ok(_mapper.Map<IEnumerable<PetViewModel>>(await this._petRepository.ObterTodosAsync()));

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PetViewModel petViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            petViewModel.UsuarioId = GetIdUser();
            var command = await this._petService.CadastrarAsync(petViewModel);
            if (command.IsSucess)
                return Ok(command);

            return BadRequest(command);
        }

        [AllowAnonymous]
        [HttpGet("categorias-pet")]
        public async Task<IActionResult> BuscarCategorias() => Ok(new CommandResult<IEnumerable<CategoriaPetViewModel>>
        {
            IsSucess = true,
            Data = _mapper.Map<IEnumerable<CategoriaPetViewModel>>(await _categoriaPetRepository.ObterTodosAsync())
        });

        private long? GetIdUser() => Convert.ToInt64(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
