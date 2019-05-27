using CreditApprover.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.Data.Repository
{
    public interface IEntityBaseRepository<TEntity>
        where TEntity : class, IEntityBase
    {
        void Add(params TEntity[] entities);
        void Delete(params TEntity[] entities);
        void Edit(params TEntity[] entities);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByAll(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
