using System.Collections.Generic;

namespace UnikMarketing.Data.Request.Queries
{
    public class GetRequestsQuery : IQuery<ICollection<Domain.Request>>
    {
        public ICollection<string> Ids { get; set; } = new List<string>();
        public ICollection<string> UserIds { get; set; } = new List<string>();
    }
}