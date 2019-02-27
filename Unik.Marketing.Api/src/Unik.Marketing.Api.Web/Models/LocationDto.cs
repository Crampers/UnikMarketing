using System.Collections.Generic;

namespace Unik.Marketing.Api.Web.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> ZipCodes { get; set; }
    }
}