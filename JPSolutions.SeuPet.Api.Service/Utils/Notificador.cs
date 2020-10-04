using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models.CommandResult;
using System.Collections.Generic;
using System.Linq;

namespace JPSolutions.SeuPet.Api.Service.Utils
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Adicionar(Notificacao notificacao)
        {
            if (!string.IsNullOrEmpty(notificacao.Mensagem))
                _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
