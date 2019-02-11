﻿namespace Unik.Marketing.Api.Domain
{
    public class Range<T>
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; }
        public T Max { get; }
    }
}