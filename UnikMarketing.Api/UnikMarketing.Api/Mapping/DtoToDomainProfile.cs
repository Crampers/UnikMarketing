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
            // TODO: Consider whether construction should be moved to a factory
            CreateMap<RangeDto<int>, Range<int>>()
                .ConstructUsing(source => new Range<int>(source.Min, source.Max));
            CreateMap<RangeDto<float>, Range<float>>()
                .ConstructUsing(source => new Range<float>(source.Min, source.Max));
            CreateMap<RangeDto<decimal>, Range<decimal>>()
                .ConstructUsing(source => new Range<decimal>(source.Min, source.Max));
            CreateMap<CriteriaDto, Criteria>();
            CreateMap<RequestDto, Request>();
        }
    }
}