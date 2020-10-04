using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : new()
    {
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ObterPorIdAsync(long id);
        Task AdicionarAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task ExcluirAsync(long id);
    }
}
