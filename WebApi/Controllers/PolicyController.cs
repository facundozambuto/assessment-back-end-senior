using BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Security;

namespace API.Controllers
{
    public class PolicyController : System.Web.Http.ApiController
    {
        private IPolicyService _policyService;
        private IClientService _clientService;
        public PolicyController(IPolicyService policyService, IClientService clientService)
        {
            this._policyService = policyService;
            this._clientService = clientService;
        }


        [System.Web.Http.Route("GetAllPolicies")]
        [BasicAuthorize]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllPolicies()
        {
            return Ok(_policyService.GetPolicies());
        }
        
        [System.Web.Http.Route("Policies/GetPoliciesByClientName/{name}")]
        [System.Web.Http.HttpGet]
        [BasicAuthorize]
        public IHttpActionResult GetPoliciesByClientName(string name)
        {
            //Try it on Postman with the name "Manning"
            var clientId = _clientService.GetClients().Where((c => c.Name == name)).FirstOrDefault().Id;

            var policies = _policyService.GetPolicies().Where((p) => p.ClientId == clientId);
            if (policies == null)
            {
                return NotFound();
            }
            return Ok(policies);
        }

    }
}