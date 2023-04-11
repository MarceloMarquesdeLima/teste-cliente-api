using System;
using Opea.Domain.Models;

namespace Opea.Domain.Interfaces.Servico
{
	public interface IClienteServico : IDisposable
	{
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        Task<bool> Remover(Guid id);
    }
}

