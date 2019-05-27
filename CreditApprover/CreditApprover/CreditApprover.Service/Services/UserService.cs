using Creditapprover.Entites.DbModel;
using CreditApprover.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApprover.Service.ServiceBase;
using CreditApprover.Authentication;
using CreditApprover.Service.Interfaces.User;

namespace CreditApprover.Service.Services
{
   public  class UserService: EntityService<UserViewModel,Login>, IUserService
    {
       // private readonly ISqlHelper _iSqlspHelper;
        public UserService(Data.UnitOfWorkImpl.IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_iSqlspHelper = unitOfWork.GetSqlHelper();
        }
        public Tuple<bool, string, int, UserViewModel> Authenticate(Login user)
        {
            try
            {
                var dbUser = this.unitOfWork.GetRepository<Login>().FirstOrDefault((x => x.MobileNo == user.MobileNo ));
               
                if (dbUser == null)
                {
                    return new Tuple<bool, string, int, UserViewModel>(false, "The user was not found.", 400, null);
                }
                var model = new UserViewModel();
                if (dbUser.Password == user.Password) {

                    model.MobileNo = user.MobileNo;
                    
                }

                var token = TokenManager.GenerateToken(Convert.ToString(user.MobileNo), model);
               
                return new Tuple<bool, string, int, UserViewModel>(true, token, 200, model);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string, int, UserViewModel>(true, string.Empty, 500, null);
            }

        }

       
    }
}
