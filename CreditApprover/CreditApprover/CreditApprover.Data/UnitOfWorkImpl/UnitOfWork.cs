using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creditapprover.Entites.DbFactory;
using CreditApprover.Data.Entity;
using CreditApprover.Data.Repository;

namespace CreditApprover.Data.UnitOfWorkImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public virtual IEntityBaseRepository<TEntity> GetRepository<TEntity>()
             where TEntity : class, IEntityBase
        {
            return new EntityBaseRepository<TEntity>(dbContext);
        }
        protected IDbFactory DbFactory
        {
            get;
        }
    }
}
