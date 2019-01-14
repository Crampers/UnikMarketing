using AutoMapper;
using UnikMarketing.Api.Models;
using UnikMarketing.Domain;

namespace UnikMarketing.Api.Mapping
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(
                    destination => destination.Criteria, 
                    options => options.NullSubstitute(new CriteriaDto())
                );
            CreateMap<LocationDto, Location>();
            CreateMap(typeof(RangeDto<>), typeof(Range<>));
            CreateMap<CriteriaDto, Criteria>();
            CreateMap<RequestDto, Request>();
        }
    }
}
