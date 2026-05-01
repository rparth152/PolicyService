using AutoMapper;
using Policy.Application.DTO;
using Policy.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PolicyTypeDTO, TypeOfPolicy>().ReverseMap();
            CreateMap<PolicyDTO, InsurancePolicy>().ReverseMap();
            CreateMap<InsurancePolicy, PolicyDTO>().ReverseMap();
            CreateMap<TypeOfPolicy, PolicyTypegetallDTO>().ReverseMap();
        }

    }
}
