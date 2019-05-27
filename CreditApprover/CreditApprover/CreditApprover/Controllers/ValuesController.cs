using Creditapprover.Entites.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CreditApprover.Service.Services;
using CreditApprover.Data.UnitOfWorkImpl;
using CreditApprover.Service.Interfaces.User;
using CreditApprover.Authentication;

namespace CreditApprover.Controllers
{
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IUserService userService;
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public ValuesController(IUnitOfWork unitOfWork, IUserService userService) {
            this.unitOfWork = unitOfWork;
            this.userService = userService;
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public Login Post(Login User)
        {
            var t = userService.Authenticate(User);
            return new Login();
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
