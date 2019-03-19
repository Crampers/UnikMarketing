using System.Collections.Generic;

namespace Unik.Marketing.Api.Data.Request.Queries
{
    public class GetRequestsQuery : IQuery<ICollection<Request>>
    {
        public ICollection<string> Ids { get; set; } = new List<string>();
        public ICollection<string> UserIds { get; set; } = new List<string>();
    }
}