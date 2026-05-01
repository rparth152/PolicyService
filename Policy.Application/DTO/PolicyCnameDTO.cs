using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.DTO
{
    public class PolicyCnameDTO
    {
        public string Policy_Name { get; set; }
        public int Customer_Id { get; set; }
        public int PolicyType_Id { get; set; }
        public DateOnly Policy_Start { get; set; }
        public DateOnly Policy_End { get; set; }
        public int Premium_Ammount { get; set; }
        public string Status { get; set; }

        public string Customer_Name { get; set; }
    }
}
