using Policy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.Interface
{
    public interface IPolicyTypeService
    {
        Task<bool> AddTypePolicy(PolicyTypeDTO dto);
        Task<PolicyTypeDTO> GetTypeById(int id);
        Task<bool> UpdateType(int id, PolicyTypeDTO dto);
        Task<bool> DeleteType(int id);
    }
}
