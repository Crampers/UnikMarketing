﻿namespace UnikMarketing.Domain
{
    public class Range<T>
    {
        public Range()
        {
            
        }
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public int Id { get; set; }
        public T Min { get; }
        public T Max { get; }
    }
}