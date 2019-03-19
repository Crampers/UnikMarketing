using AutoMapper;
using Unik.Marketing.Api.Data.MongoDb.Request;
using Unik.Marketing.Api.Data.MongoDb.User;
using Unik.Marketing.Api.Data.User;

namespace Unik.Marketing.Api.Data.MongoDb.Mapping
{
    internal class DomainToDocumentProfile : Profile
    {
        public DomainToDocumentProfile()
        {
            CreateMap<Data.Request.Request, RequestDocument>();
            CreateMap<Data.User.User, UserDocument>();
            CreateMap<Criteria, CriteriaDocument>()
                .ForMember(
                    member => member.FloorFrom,
                    options => options.MapFrom(source => source.Floor.Min)
                ).ForMember(
                    member => member.FloorTo,
                    options => options.MapFrom(source => source.Floor.Max)
                ).ForMember(
                    member => member.SizeFrom,
                    options => options.MapFrom(source => source.Size.Min)
                ).ForMember(
                    member => member.SizeTo,
                    options => options.MapFrom(source => source.Size.Max)
                ).ForMember(
                    member => member.PriceFrom,
                    options => options.MapFrom(source => source.Price.Min)
                ).ForMember(
                    member => member.PriceTo,
                    options => options.MapFrom(source => source.Price.Max)
                );
        }
    }
}