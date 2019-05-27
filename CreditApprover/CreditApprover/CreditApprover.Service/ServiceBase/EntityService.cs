using AutoMapper;
using CreditApprover.Data.Entity;
using CreditApprover.Data.Repository;
using CreditApprover.Data.UnitOfWorkImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.Service.ServiceBase
{
    public partial class EntityService<TViewModel, TEntity> : IEntityService<TViewModel, TEntity>
       where TViewModel : class
       where TEntity : class, IEntityBase
    {
        protected readonly IEntityBaseRepository<TEntity> entityBaseRepository = null;
        protected readonly IUnitOfWork unitOfWork = null;
        public EntityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.entityBaseRepository = this.unitOfWork.GetRepository<TEntity>();
        }
        public void Add(params TViewModel[] entities)
        {
            entities = entities ?? new TViewModel[0];
            entityBaseRepository.Add(Mapper.Map<TViewModel[], TEntity[]>(entities));
        }

        public void Delete(params TViewModel[] entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(params TViewModel[] entities)
        {
            throw new NotImplementedException();
        }

        public TViewModel FirstOrDefault(Expression<Func<TViewModel, bool>> predicate)
        {
            var dbModel = entityBaseRepository.FirstOrDefault(Mapper.Map<Expression<Func<TViewModel, bool>>, Expression<Func<TEntity, bool>>>(predicate));
            return Mapper.Map<TEntity, TViewModel>(dbModel);
        }

        public IList<TViewModel> Get(Expression<Func<TViewModel, bool>> predicate)
        {
            var entities = entityBaseRepository.FindBy(Mapper.Map<Expression<Func<TViewModel, bool>>, Expression<Func<TEntity, bool>>>(predicate)).ToList();
            return Mapper.Map<List<TEntity>, List<TViewModel>>(entities);
        }

        public IList<TViewModel> GetAll()
        {
            var entities = entityBaseRepository.GetAll().ToList();
            return Mapper.Map<List<TEntity>, List<TViewModel>>(entities);
        }
    }
}
