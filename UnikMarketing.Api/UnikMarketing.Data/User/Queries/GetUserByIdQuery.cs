namespace UnikMarketing.Data.User.Queries
{
    public class GetUserByIdQuery : IQuery<Domain.User>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}