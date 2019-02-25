using System.Collections.Generic;

namespace Unik.Marketing.Api.Data.User
{
    public class Criteria
    {
        public int Id { get; set; }
        public Range<decimal> Size { get; set; }
        public Range<decimal> Price { get; set; }
        public Range<int> Floor { get; set; }
        public ICollection<Location> Locations { get; } = new List<Location>();
    }
}