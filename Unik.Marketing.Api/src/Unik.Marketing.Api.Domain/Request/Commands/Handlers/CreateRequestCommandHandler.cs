using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Request>
    {
        private readonly IRepository<Request> _repository;

        public CreateRequestCommandHandler(IRepository<Request> repository)
        {
            _repository = repository;
        }

        public async Task<Request> Handle(CreateRequestCommand command)
        {
            var request = new Request(command.Note, command.UserId);

            await _repository.Save(request);

            return request;
        }
    }
}