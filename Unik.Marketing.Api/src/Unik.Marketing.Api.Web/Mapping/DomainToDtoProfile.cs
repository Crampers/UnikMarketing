﻿using AutoMapper;
using Unik.Marketing.Api.Domain.Request;
using Unik.Marketing.Api.Domain.User;
using Unik.Marketing.Api.Web.Models;
using Unik.Marketing.Api.Web.Models.Request;

namespace Unik.Marketing.Api.Web.Mapping
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