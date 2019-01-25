namespace UnikMarketing.Data.Queries.Request
{
    public class GetRequestByIdQuery : IQuery<Domain.Request>
    {
        public string Id { get; set; }
    }
}
