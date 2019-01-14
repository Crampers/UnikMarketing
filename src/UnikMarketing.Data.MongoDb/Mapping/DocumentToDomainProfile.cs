using AutoMapper;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Domain;

namespace UnikMarketing.Data.MongoDb.Mapping
{
    class DocumentToDomainProfile : Profile
    {
        public DocumentToDomainProfile()
        {
            CreateMap<RequestDocument, Request>();
            CreateMap<UserDocument, User>();
            CreateMap<CriteriaDocument, Criteria>()
                .ForMember(
                    member => member.Floor.Min,
                    options => options.MapFrom(source => source.FloorFrom)
                ).ForMember(
                    member => member.Floor.Max,
                    options => options.MapFrom(source => source.FloorTo)
                ).ForMember(
                    member => member.Size.Min,
                    options => options.MapFrom(source => source.SizeFrom)
                ).ForMember(
                    member => member.Size.Max,
                    options => options.MapFrom(source => source.SizeTo)
                ).ForMember(
                    member => member.Price.Min,
                    options => options.MapFrom(source => source.PriceFrom)
                ).ForMember(
                    member => member.Price.Max,
                    options => options.MapFrom(source => source.PriceTo)
                );
        }
    }
}
