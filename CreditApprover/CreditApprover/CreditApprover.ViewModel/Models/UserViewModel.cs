using Creditapprover.Entites.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApprover.ViewModel.Models
{
  public class UserViewModel
    {
        public int Id { get; set; }
        public Nullable<long> MobileNo { get; set; }
        public string Password { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public virtual Login Login { get; set; }
    }
}
