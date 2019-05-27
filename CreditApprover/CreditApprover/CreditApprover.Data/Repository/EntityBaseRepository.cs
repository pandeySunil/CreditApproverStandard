using CreditApprover.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;


namespace CreditApprover.Data.Repository
{
    internal class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity>
        where TEntity : class, IEntityBase
    {
        private DbContext dbContext;
        public EntityBaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(params TEntity[] entities)
        {
            entities = entities ?? new TEntity[0];
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindByAll(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var t = dbContext.Set<TEntity>().FirstOrDefault();

            return dbContext.Set<TEntity>().FirstOrDefault(predicate);
            //dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            includeProperties = includeProperties ?? new Expression<Func<TEntity, object>>[0];
            var query = dbContext.Set<TEntity>();
            // return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.AsQueryable();
        }
       
    }
}
