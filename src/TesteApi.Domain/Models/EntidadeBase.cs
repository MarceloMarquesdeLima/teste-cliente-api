
using System;
namespace Opea.Domain.Models
{
	public abstract class EntidadeBase
	{
		protected EntidadeBase()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
	}
}

