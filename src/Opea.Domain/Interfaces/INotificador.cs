using System;
using Opea.Domain.Notificacoes;

namespace Opea.Domain.Interfaces
{
	public interface INotificador
	{
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}

