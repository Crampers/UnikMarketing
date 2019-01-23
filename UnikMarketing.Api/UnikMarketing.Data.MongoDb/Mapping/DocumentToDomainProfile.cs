using AutoMapper;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Domain;

namespace UnikMarketing.Data.MongoDb.Mapping
{
    internal class DocumentToDomainProfile : Profile
    {
        public DocumentToDomainProfile()
        {
            CreateMap<RequestDocument, Request>();
            CreateMap<UserDocument, User>();
            CreateMap<Location, Location>();
            CreateMap<CriteriaDocument, Criteria>()
                .ForPath(
                    member => member.Floor,
                    options => options.MapFrom(source => new Range<int>(source.FloorFrom, source.FloorTo))
                ).ForPath(
                    member => member.Size,
                    options => options.MapFrom(source => new Range<decimal>(source.SizeFrom, source.SizeTo))
                ).ForPath(
                    member => member.Price,
                    options => options.MapFrom(source => new Range<decimal>(source.PriceFrom, source.PriceTo))
                );
        }
    }
}