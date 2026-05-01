using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.DTO
{
    public class PolicyTypegetallDTO
    {
        public int Type_Id { get; set; }
        public string Type_Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
