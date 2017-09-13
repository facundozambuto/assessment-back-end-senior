using BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Security;

namespace API.Controllers
{
    public class ClientController : ApiController
    {
        private IClientService _clientService;
        private IPolicyService _policyService;
        public ClientController(IClientService clientService, IPolicyService policyService)
        {
            this._clientService = clientService;
            this._policyService = policyService;
        }

        [System.Web.Http.Route("GetAllClients")]
        [BasicAuthorize]
        public IHttpActionResult GetAllClients()
        {
            return Ok(_clientService.GetClients());
        }

        [System.Web.Http.Route("Clients/GetClientById/{id}")]
        [System.Web.Http.HttpGet]
        [BasicAuthorize]
        public IHttpActionResult GetClientById(string id)
        {
            //Try this endpoint on Postman with any Client Id such as "880abb11-936a-45d0-880d-a9fb4d669086". It outgh to return Dotson's profile data.
            var client = _clientService.GetClients().FirstOrDefault((c) => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [System.Web.Http.Route("Clients/GetClientByName/{name}")]
        [System.Web.Http.HttpGet]
        [BasicAuthorize]
        public IHttpActionResult GetClientByName(string name)
        {
            //Try this endpoint on Postman with "Dotson". It will fetch his entire profile data.
            var client = _clientService.GetClients().FirstOrDefault((c) => c.Name == name);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [System.Web.Http.Route("Clients/GetClientByPolicyId/{policyId}")]
        [System.Web.Http.HttpGet]
        [BasicAuthorize]
        public IHttpActionResult GetClientByPolicyId(string policyId)
        {
            //Try to get the client data on Postman with the following Policy ID "0eba1179-6155-41b5-bdd8-f80e1ac94cab". It should return Manning's profile
            var clientId = _policyService.GetPolicies().Where((p) => p.Id == policyId).FirstOrDefault().ClientId;
            var client = _clientService.GetClients().FirstOrDefault((c) => c.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        private string RetrieveUser()
        {
            HttpContext httpContext = HttpContext.Current;

            string authHeader = httpContext.Request.Headers["Authorization"];


            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int seperatorIndex = usernamePassword.IndexOf(':');

            var username = usernamePassword.Substring(0, seperatorIndex);
            var password = usernamePassword.Substring(seperatorIndex + 1);
            return username;
        }
    }
}