using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UnikMarketing.Api.Models;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Mapping
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Location, LocationDto>();
            CreateMap(typeof(Range<>), typeof(RangeDto<>));
            CreateMap<Criteria, CriteriaDto>();
            CreateMap<Request, RequestDto>();
        }
    }
}
