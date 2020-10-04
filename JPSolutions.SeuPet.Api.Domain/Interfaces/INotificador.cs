using JPSolutions.SeuPet.Api.Domain.Models.CommandResult;
using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Adicionar(Notificacao notificacao);
    }
}
