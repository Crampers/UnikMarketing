using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, Request>
    {
        private readonly IRepository<Request> _repository;

        public UpdateNoteCommandHandler(IRepository<Request> repository)
        {
            _repository = repository;
        }

        public async Task<Request> Handle(UpdateNoteCommand command)
        {
            var request = await _repository.Get(Guid.Parse(command.Id));

            request.UpdateNote(command.Note);

            await _repository.Save(request);

            return request;
        }
    }
}