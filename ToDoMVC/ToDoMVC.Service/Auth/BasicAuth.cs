using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ToDoMVC.Service.Auth
{
    public class BasicAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (context.Request.Headers.Authorization == null)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = context.Request.Headers.Authorization.Parameter;
                string decodeToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string username = decodeToken.Substring(0, decodeToken.IndexOf(":"));
                string password = decodeToken.Substring(decodeToken.IndexOf(":") + 1);

                if (username == "dreddit" && password == "isrecruiting")
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(username), new string[] { });
                    base.OnActionExecuting(context);
                }
                else
                {
                    context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}