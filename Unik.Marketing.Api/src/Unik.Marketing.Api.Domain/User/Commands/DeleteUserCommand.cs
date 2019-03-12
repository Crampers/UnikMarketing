namespace Unik.Marketing.Api.Domain.User.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}