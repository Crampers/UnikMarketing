using System.Collections.Generic;

namespace UnikMarketing.Data.Request.Queries
{
    public class GetRequestsQuery : IQuery<ICollection<Domain.Request>>
    {
        public List<string> UserIds { get; set; }
    }
}