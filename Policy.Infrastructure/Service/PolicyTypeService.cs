using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Policy.Application.DTO;
using Policy.Application.Interface;
using Policy.Domain.Model;
using Policy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Infrastructure.Service
{
    public class PolicyTypeService : IPolicyTypeService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public PolicyTypeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> AddTypePolicy(PolicyTypeDTO dto)
        {
            var data = mapper.Map<TypeOfPolicy>(dto);
            await db.TypeOfPolicies.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        

        public async Task<bool> DeleteType(int id)
        {
            var data = await db.TypeOfPolicies.FindAsync(id);
            data.Status = "InActive";
            await db.SaveChangesAsync();
            return true;


        }

        public async Task<PolicyTypeDTO> GetTypeById(int id)
        {

            var data = await db.TypeOfPolicies.FindAsync(id);
            return mapper.Map<PolicyTypeDTO>(data);
        }
        public async Task<List<PolicyTypegetallDTO>> GetAllPolicies() {
            var data = await db.TypeOfPolicies.Where(x => x.Status == "Active").ToListAsync();
            return mapper.Map<List<PolicyTypegetallDTO>>(data);
        }
        public async Task<bool> UpdateType(int id, PolicyTypeDTO dto)
        {
            var data = await db.TypeOfPolicies.FindAsync(id);
            mapper.Map(dto, data);
            await db.SaveChangesAsync();
            return true;
        }

       

       
    }
}
