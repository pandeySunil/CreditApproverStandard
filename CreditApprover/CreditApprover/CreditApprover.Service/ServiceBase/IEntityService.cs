using CreditApprover.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.Service.ServiceBase
{
    public partial interface IEntityService<TViewModel, TEntity>
       where TViewModel : class
       where TEntity : class, IEntityBase
    {
        void Add(params TViewModel[] entities);
        void Delete(params TViewModel[] entities);
        void Edit(params TViewModel[] entities);
        TViewModel FirstOrDefault(Expression<Func<TViewModel, bool>> predicate);
        IList<TViewModel> Get(Expression<Func<TViewModel, bool>> predicate);
        IList<TViewModel> GetAll();
    }
}
