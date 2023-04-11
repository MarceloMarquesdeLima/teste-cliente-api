using System;
using FluentValidation;

namespace Opea.Domain.Models.Validacao
{
	public class ClienteValidacao : AbstractValidator<Cliente>
	{
		public ClienteValidacao()
		{
			RuleFor(c => c.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
				.Length(2, 150)
				.WithMessage("O campo {propertyName} precisa ter entre {MinLength} e {MaxLength} de caracteres.");
		}
	}
}

