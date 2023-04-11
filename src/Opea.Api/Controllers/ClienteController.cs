using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opea.Domain.Interfaces;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Interfaces.Servico;

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
    }
}

