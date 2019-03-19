using AutoMapper;
using Unik.Marketing.Api.Data.MongoDb.Request;
using Unik.Marketing.Api.Data.MongoDb.User;
using Unik.Marketing.Api.Data.User;

namespace Unik.Marketing.Api.Data.MongoDb.Mapping
{
    internal class DocumentToDomainProfile : Profile
    {
        public DocumentToDomainProfile()
        {
            CreateMap<RequestDocument, Data.Request.Request>();
            CreateMap<UserDocument, Data.User.User>();
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