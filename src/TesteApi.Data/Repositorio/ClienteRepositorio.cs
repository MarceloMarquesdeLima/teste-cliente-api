using Microsoft.EntityFrameworkCore;
using Opea.Data.Context;
using Opea.Data.Repositorio;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApi.Data.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterCliente()
        {
            return await Db.Clientes.AsNoTracking().Include(c => c.Nome)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<Cliente> ObterClientePorId(Guid id)
        {
            return await Db.Clientes.Include(c => c.Id).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
