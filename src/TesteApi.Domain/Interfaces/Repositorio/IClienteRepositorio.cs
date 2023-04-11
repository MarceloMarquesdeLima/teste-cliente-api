using System;
using Opea.Domain.Models;

namespace Opea.Domain.Interfaces.Repositorio
{
	public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterCliente();
        Task<Cliente> ObterClientePorId(Guid id);
    }
}

