using System;
using System.Linq.Expressions;
using Opea.Domain.Models;

namespace Opea.Domain.Interfaces.Repositorio
{
	public interface IRepositorio<TEntidade> : IDisposable where TEntidade : EntidadeBase
	{
		Task Adicionar(TEntidade entidade);
		Task<TEntidade> ObterPorId(Guid id);
        Task<List<TEntidade>> ObterTodos();
        Task Atualizar(TEntidade entidade);
        Task Remover(Guid id);
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate);
        Task<int> SaveChanges();
    }
}

