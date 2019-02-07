using System.Collections.Generic;

namespace Unik.Marketing.Api.Data.User.Queries
{
    public class GetUsersQuery : IQuery<ICollection<Domain.User>>
    {
        public ICollection<string> Ids { get; set; } = new List<string>();
    }
}