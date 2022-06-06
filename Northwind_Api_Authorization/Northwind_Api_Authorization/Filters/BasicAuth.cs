using Northwind_Api_Authorization.Tools;
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

namespace Northwind_Api_Authorization.Filters
{
    public class BasicAuth: AuthorizationFilterAttribute
    {
        //filtre AuthorizationFilterAttribute miras alıyor

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                //istek yoksa
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Yetkisiz giriş sağlanamaz!");
            }
            else
            {
                var authParameter= actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthParameter = Encoding.UTF8.GetString(Convert.FromBase64String(authParameter));
                string[] userNameAndPasswordArray = decodeAuthParameter.Split(':');

                string firstName = userNameAndPasswordArray[0];  //String ifadeleri birbirinden ayırmış olduk
                string lastName = userNameAndPasswordArray[1];

                if (LoginEmployee.AnyEmployee(firstName, lastName))
                {
                    GenericIdentity identiy = new GenericIdentity(firstName);
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