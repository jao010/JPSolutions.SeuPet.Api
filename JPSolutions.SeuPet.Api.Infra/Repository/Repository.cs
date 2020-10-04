using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Domain.Models;
using JPSolutions.SeuPet.Api.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JPSolutions.SeuPet.Api.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SeuPetContext SeuPetContext;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(SeuPetContext db)
        {
            SeuPetContext = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task AdicionarAsync(TEntity entity)
        {
            this.DbSet.Add(entity);
            await this.SeuPetContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await this.SeuPetContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await this.SeuPetContext.SaveChangesAsync();
        }

        public async Task<TEntity> ObterPorIdAsync(long id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.SeuPetContext.Dispose();
            }
        }
    }
}
