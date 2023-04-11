using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opea.Api.ViewModels;
using Opea.Domain.Interfaces;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Interfaces.Servico;
using Opea.Domain.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opea.Api.Controllers
{
    [Route("api/fornecedores")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteServico _clienteServico;
        private readonly IMapper _mapper;

        public ClienteController(INotificador notificador) : base(notificador)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepositorio.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterPorId(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteServico.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(clienteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteServico.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Excluir(Guid id)
        {
            var clienteViewModel = await ObterPorId(id);

            if (clienteViewModel == null) return NotFound();

            await _clienteServico.Remover(id);

            return CustomResponse(clienteViewModel);
        }


        public async Task<ClienteViewModel> ObterCliente(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepositorio.ObterPorId(id));
        }

        public async Task<ClienteViewModel> ObterCliente()
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepositorio.ObterCliente());
        }
    }
}

