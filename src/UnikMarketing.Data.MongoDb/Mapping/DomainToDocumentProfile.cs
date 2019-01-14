using AutoMapper;
using UnikMarketing.Data.MongoDb.Documents;
using UnikMarketing.Domain;

namespace UnikMarketing.Data.MongoDb.Mapping
{
    class DomainToDocumentProfile : Profile
    {
        public DomainToDocumentProfile()
        {
            CreateMap<Request, RequestDocument>();
        }
    }
}
