using AutoMapper;
using DataAccess.Contracts;
using DTO.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class PolicyService : IPolicyService
    {
        private IPolicyRepository _policyRepository;
        public PolicyService(IPolicyRepository policyRepository)
        {
            this._policyRepository = policyRepository;
        }

        IEnumerable<PolicyDTO> IPolicyService.GetPolicies()
        {
            var policies = _policyRepository.GetPolicies();
            return Mapper.Map<List<PolicyDTO>>(policies);
        }
    }
}
