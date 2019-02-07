namespace Unik.Marketing.Api.Web.Models
{
    public class RangeDto<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}