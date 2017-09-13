using DTO.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public interface IPolicyService
    {
        IEnumerable<PolicyDTO> GetPolicies();
    }
}
