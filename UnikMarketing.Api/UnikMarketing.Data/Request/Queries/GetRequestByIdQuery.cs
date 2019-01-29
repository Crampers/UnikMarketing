namespace UnikMarketing.Data.Queries.Request
{
    public class GetRequestByIdQuery : IQuery<Domain.Request>
    {
        public GetRequestByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
