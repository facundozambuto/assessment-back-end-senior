using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Security
{
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Here, I've used a Basic authorization to allow getting the response. To do that, it has to get the role of the User who is making the request.
            //To try this, there should choose "Basic Auth" on Postman and set a real client's name in order to get his/her role (could be admin or user, if there is one with another role, he or she will be not allowed to get the responses.
            var headers = actionContext.Request.Headers;
            var controllerName = actionContext.ActionDescriptor.ActionName;
            if (headers.Authorization != null && headers.Authorization.Scheme == "Basic")
            {
                try
                {
                    var userPwd = Encoding.UTF8.GetString(Convert.FromBase64String(headers.Authorization.Parameter));
                    var user = userPwd.Substring(0, userPwd.IndexOf(':'));
                    var password = userPwd.Substring(userPwd.IndexOf(':') + 1);

                    string userRole = GetRoleClient(user);

                    if (controllerName == "GetAllPolicies" || controllerName == "GetAllClients" || controllerName == "GetClientByName" || controllerName == "GetClientById")
                    {
                        if (!(userRole == "admin" || userRole == "user"))
                        {
                            PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                        }
                    }
                    else if (controllerName == "GetPoliciesByClientName" || controllerName == "GetClientByPolicyId")
                    {
                        if (!(userRole == "admin"))
                        {
                            PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                        }
                    }                    
                }
                catch (Exception)
                {
                    PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                }
            }
            else
            {
                // There is no authorization in the header
                PutUnauthorizedResult(actionContext, "Auhtorization needed");
            }
        }

        private void PutUnauthorizedResult(HttpActionContext actionContext, string msg)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(msg)
            };
        }

        private string GetRoleClient(string clientId)
        {
            //Here, I put this "repository" in order to get all the users and get each role. In fact, there should be another call to the API to get them.
            List<Client> clients = new List<Client>()
            {
                new Client(){Id = "880abb11-936a-45d0-880d-a9fb4d669086", Name = "Dotson", Email = "dotsonblankenship@quotezart.com", Role = "admin" },
                new Client(){Id = "065eb093-748e-4133-9884-0adc11e2fbfc", Name = "Marietta", Email = "mariettablankenship@quotezart.com", Role = "user" },
                new Client(){Id = "011dd3d8-2d1e-4abe-9efc-006a1a4a0399", Name = "Sherrie", Email = "sherrieblankenship@quotezart.com", Role = "user" },
                new Client(){Id = "1f00dd51-3583-40a0-8350-a2df96b505a9", Name = "Moore", Email = "mooreblankenship@quotezart.com", Role = "user" },
                new Client(){Id = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb", Name = "Manning", Email = "manningblankenship@quotezart.com", Role = "admin" }
            };

            var role = clients.Where(x => x.Name == clientId).FirstOrDefault().Role;
            return role;
        }
    }
}