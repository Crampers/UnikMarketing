using System.Collections.Generic;

namespace Unik.Marketing.Api.Business.User.Queries
{
    public class GetUsersQuery : IQuery<ICollection<Domain.User>>
    {
        public ICollection<string> Ids { get; set; } = new List<string>();
    }
}