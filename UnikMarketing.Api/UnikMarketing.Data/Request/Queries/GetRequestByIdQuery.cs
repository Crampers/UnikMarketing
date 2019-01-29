namespace UnikMarketing.Data.Request.Queries
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