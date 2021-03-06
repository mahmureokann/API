using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApi_Authentication.Tools;

namespace WebApi_Authentication.Filters
{
    public class BasicAuth:AuthorizationFilterAttribute
    {
       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Yetkisiz giriş yasaktır!");
            }
            else
            {
                var autParameter = actionContext.Request.Headers.Authorization.Parameter;//Base64
                string decodeAuthParameter = Encoding.UTF8.GetString(Convert.FromBase64String(autParameter));//admin:1234
                string[] userNameAndPasswordArray = decodeAuthParameter.Split(':');

                string userName = userNameAndPasswordArray[0];
                string password= userNameAndPasswordArray[1];

                if (LoginCredentials.AnyUser(userName, password))
                {
                    GenericIdentity identiy = new GenericIdentity(userName);
                    Thread.CurrentPrincipal = new GenericPrincipal(identiy, null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Yetkisiz giriş yasaktır!");
                }
            }



            base.OnAuthorization(actionContext);
        }
    }
}