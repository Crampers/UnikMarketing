using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Domain.Request.Request>
    {
        private readonly IRepository<Domain.Request.Request> _repository;

        public CreateRequestCommandHandler(IRepository<Domain.Request.Request> repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Request.Request> Handle(CreateRequestCommand command)
        {
            var request = new Domain.Request.Request(command.Note, command.UserId);

            await _repository.Save(request);

            return request;
        }
    }
}