using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Policy.Application.DTO;
using Policy.Application.Interface;
using Policy.Domain.Model;
using Policy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Policy.Infrastructure.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly ApplicationDbContext db;
        private readonly CustomerClient customerClient;
        private readonly IMapper mapper;

        public PolicyService(ApplicationDbContext db, IMapper mapper, CustomerClient customerClient)
        {
            this.db = db;
            this.mapper = mapper;
            this.customerClient = customerClient;
        }

        public async Task<bool> AddPolicy(PolicyDTO dto)
        {
            var data = mapper.Map<InsurancePolicy>(dto);
            await db.InsurancePolicies.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePolicy(int id)
        {
            var data = await db.InsurancePolicies.FindAsync(id);
            data.Status = "InActive";
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<PolicyCnameDTO>> GetAllPolicies()
        {
            var policies = await db.InsurancePolicies.ToListAsync();
            var result = new List<PolicyCnameDTO>();

            foreach (var policy in policies)
            {
                var mapped = mapper.Map<PolicyCnameDTO>(policy);
                var customer = await customerClient.GetCustomerById(policy.Customer_Id);
                mapped.Customer_Name = customer?.Customer_Name;
                result.Add(mapped);
            }

            return result;
        }

        public async Task<PolicyCnameDTO> GetPolicyByID(int id)
        {
            var data = await db.InsurancePolicies.FindAsync(id);

            if (data == null)
                throw new Exception("Policy not found");

            var res = mapper.Map<PolicyCnameDTO>(data);
            var customer = await customerClient.GetCustomerById(data.Customer_Id);
            res.Customer_Name = customer.Customer_Name;

            return res;
        }
         
        public async Task<bool> UpdatePolicy(int id, PolicyDTO dto)
        {
            var data = await db.InsurancePolicies.FindAsync(id);
            mapper.Map(dto, data);
            await db.SaveChangesAsync();
            return true;
        }
    }
}