using System.Collections.Generic;

namespace UnikMarketing.Api.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> ZipCodes { get; set; }
    }
}