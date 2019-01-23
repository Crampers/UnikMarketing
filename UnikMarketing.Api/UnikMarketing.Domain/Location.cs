using System.Collections.Generic;

namespace UnikMarketing.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> ZipCodes { get; } = new List<string>();
    }
}