namespace UnikMarketing.Data.Queries.User
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