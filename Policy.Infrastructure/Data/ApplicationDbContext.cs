using Microsoft.EntityFrameworkCore;
using Policy.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<TypeOfPolicy> TypeOfPolicies { get; set; }

    }
}
