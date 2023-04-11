using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Opea.Data.Context;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Models;

namespace Opea.Data.Repositorio
{
	public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : EntidadeBase
	{
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntidade> DbSet;

		public Repositorio(ApplicationDbContext db)
		{
            Db = db;
            DbSet = db.Set<TEntidade>();
		}

        public virtual async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }


        public async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<TEntidade> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}

