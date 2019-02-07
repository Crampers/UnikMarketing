using System.Collections.Generic;

namespace Unik.Marketing.Api.Web.Models
{
    public class CriteriaDto
    {
        public int Id { get; set; }
        public RangeDto<decimal> Size { get; set; }
        public RangeDto<decimal> Price { get; set; }
        public RangeDto<int> Floor { get; set; }
        public ICollection<LocationDto> Locations { get; set; }
    }
}