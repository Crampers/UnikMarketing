namespace UnikMarketing.Data.Queries.User
{
    public class GetUserByIdQuery : IQuery<Domain.User>
    {
        public string Id { get; set; }
    }
}