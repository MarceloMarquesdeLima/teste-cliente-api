using System;
using Opea.Domain.Interfaces;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Interfaces.Servico;
using Opea.Domain.Models;
using Opea.Domain.Models.Validacao;

namespace Opea.Domain.Servico
{
	public class ClienteServico : ServicoBasico, IClienteServico
	{
        private readonly IClienteRepositorio _clienteRepositorio;

		public ClienteServico(IClienteRepositorio clienteRepositorio, INotificador notificador) : base(notificador)
		{
            _clienteRepositorio = clienteRepositorio;
		}

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidacao(), cliente)) return false;

            if(_clienteRepositorio.Buscar(c => c.Nome == cliente.Nome).Result.Any())
            {
                Notificar("Já existe um cliente com este nome informador.");
                return false;
            }

            await _clienteRepositorio.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if(!ExecutarValidacao(new ClienteValidacao(), cliente)) return false;

            if (_clienteRepositorio.Buscar(c => c.Id == cliente.Id && c.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe um cliente com este Id infomado.");
                return false;
            }

            await _clienteRepositorio.Atualizar(cliente);
            return true;
        }

        public void Dispose()
        {
            _clienteRepositorio?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_clienteRepositorio.ObterClientePorId(id).Result.Nome.Any())
            {
                Notificar("O cliente não possui cadastrado!");
                return false;
            }

            await _clienteRepositorio.Remover(id);
            return true;
        }
    }
}

