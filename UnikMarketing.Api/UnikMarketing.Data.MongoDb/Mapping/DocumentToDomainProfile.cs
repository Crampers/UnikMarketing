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
                .ForPath(
                    member => member.Floor.Min,
                    options => options.MapFrom(source => source.FloorFrom)
                ).ForPath(
                    member => member.Floor.Max,
                    options => options.MapFrom(source => source.FloorTo)
                ).ForPath(
                    member => member.Size.Min,
                    options => options.MapFrom(source => source.SizeFrom)
                ).ForPath(
                    member => member.Size.Max,
                    options => options.MapFrom(source => source.SizeTo)
                ).ForPath(
                    member => member.Price.Min,
                    options => options.MapFrom(source => source.PriceFrom)
                ).ForPath(
                    member => member.Price.Max,
                    options => options.MapFrom(source => source.PriceTo)
                );
        }
    }
}
