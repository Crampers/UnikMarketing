using System.Collections.Generic;

namespace Unik.Marketing.Api.Business.Domain.User
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> ZipCodes { get; } = new List<string>();
    }
}