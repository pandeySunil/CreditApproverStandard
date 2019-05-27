using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace CreditApprover.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjgyMDgwOTAzMjQiLCJuYmYiOjE1NTg5NTkwOTIsImV4cCI6MTU1OTgyMzA5MiwiaWF0IjoxNTU4OTU5MDkyLCJ1c2VyRGF0YSI6IntcIklkXCI6MCxcIk1vYmlsZU5vXCI6ODIwODA5MDMyNCxcIlBhc3N3b3JkXCI6bnVsbCxcIlVzZXJJZFwiOm51bGwsXCJGaXJzdE5hbWVcIjpudWxsLFwiTGFzdE5hbWVcIjpudWxsLFwiUGhvdG9cIjpudWxsLFwiTG9naW5cIjpudWxsfSJ9.NWRLLmJebQjQx7v1T5C5PCppeGRk8NwxEDRRkgdzmHo";
            TokenManager.GetPrincipal(token);
        }
    }
}