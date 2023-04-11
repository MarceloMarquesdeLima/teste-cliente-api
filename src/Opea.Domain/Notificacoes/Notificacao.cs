using System;
namespace Opea.Domain.Notificacoes
{
	public class Notificacao
	{
		public Notificacao(string mensagem)
		{
			mensagem = mensagem;
		}
		public string Mensagem { get; set; }
	}
}

