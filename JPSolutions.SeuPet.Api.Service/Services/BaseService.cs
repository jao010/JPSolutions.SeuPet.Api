using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models.CommandResult;
using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Service.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            this._notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }

        protected CommandResult<List<Notificacao>> CommandResultError()
        {
            return new CommandResult<List<Notificacao>>
            {
                IsSucess = false,
                Data = _notificador.ObterNotificacoes(),
                Message = "Houve algum erro!"
            };
        }

        protected CommandResult<T> CommandResultSucess<T>(T obj)
        {
            return new CommandResult<T>
            {
                IsSucess = true,
                Data = obj
            };
        }
    }
}
