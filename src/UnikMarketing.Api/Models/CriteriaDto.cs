using System.Collections.Generic;

namespace UnikMarketing.Api.Models
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