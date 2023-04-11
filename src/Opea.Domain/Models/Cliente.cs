using System;
using Opea.Domain.Models.Enum;

namespace Opea.Domain.Models
{
	public class Cliente : EntidadeBase
	{
		public string Nome { get; set; }
		public PorteEnum Porte { get; set; }
	}
}

