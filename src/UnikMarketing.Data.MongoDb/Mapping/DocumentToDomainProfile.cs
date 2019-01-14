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
        }
    }
}
