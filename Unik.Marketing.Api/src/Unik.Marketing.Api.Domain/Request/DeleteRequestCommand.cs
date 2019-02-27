namespace Unik.Marketing.Api.Business.Request
{
    public class DeleteRequestCommand : ICommand
    {
        public DeleteRequestCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}