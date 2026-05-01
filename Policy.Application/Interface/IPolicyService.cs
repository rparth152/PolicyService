using Policy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.Interface
{
    public interface IPolicyService
    {
        Task<bool> AddPolicy(PolicyDTO dto);
        Task<PolicyCnameDTO> GetPolicyByID(int id);
        Task<List<PolicyCnameDTO>> GetAllPolicies();
        Task<bool> UpdatePolicy(int id, PolicyDTO dto);
        Task<bool> DeletePolicy(int id);
    }
}
