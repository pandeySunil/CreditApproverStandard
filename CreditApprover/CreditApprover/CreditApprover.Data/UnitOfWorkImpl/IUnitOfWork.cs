using CreditApprover.Data.Entity;
using CreditApprover.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.Data.UnitOfWorkImpl
{
   public interface IUnitOfWork
    {
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IEntityBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntityBase;

    }
}
