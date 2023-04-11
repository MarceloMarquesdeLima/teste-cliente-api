using FluentValidation;
using Opea.Domain.Interfaces;
using Opea.Domain.Notificacoes;
using FluentValidation.Results;

namespace Opea.Domain.Servico
{
	public abstract class ServicoBasico
	{
        private readonly INotificador _notificador;

        public ServicoBasico(INotificador notificador)
		{
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Models.EntidadeBase
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}

