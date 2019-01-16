namespace UnikMarketing.Api.Models
{
    public class RangeDto<T>
    {
        public int Id { get; set; }
        public T Min { get; set; }
        public T Max { get; set; }
    }
}