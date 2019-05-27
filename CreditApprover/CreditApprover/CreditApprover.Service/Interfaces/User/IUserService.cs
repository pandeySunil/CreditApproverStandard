using Creditapprover.Entites.DbModel;
using CreditApprover.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.Service.Interfaces.User
{
    public interface IUserService
    {
        Tuple<bool, string, int, UserViewModel> Authenticate(Login user);
    }
}
