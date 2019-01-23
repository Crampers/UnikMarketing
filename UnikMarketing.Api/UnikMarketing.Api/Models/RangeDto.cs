namespace UnikMarketing.Api.Models
{
    public class RangeDto<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
    }
}