using AutoMapper;
using UnikMarketing.Api.Models;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Mapping
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<LocationDto, Location>();
            CreateMap(typeof(RangeDto<>), typeof(Range<>));
            CreateMap<CriteriaDto, Criteria>();
            CreateMap<RequestDto, Request>();
        }
    }
}
