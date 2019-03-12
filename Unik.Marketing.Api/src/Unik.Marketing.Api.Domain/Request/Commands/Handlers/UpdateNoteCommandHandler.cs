using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.Request.Commands.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, Domain.Request.Request>
    {
        private readonly IRepository<Domain.Request.Request> _repository;

        public UpdateNoteCommandHandler(IRepository<Domain.Request.Request> repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Request.Request> Handle(UpdateNoteCommand command)
        {
            var request = await _repository.Get(Guid.Parse(command.Id));

            request.UpdateNote(command.Note);

            await _repository.Save(request);

            return request;
        }
    }
}