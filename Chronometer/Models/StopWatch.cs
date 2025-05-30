namespace Chronometer.Models
{
    using System;

    public class StopWatch
    {
        public TimeSpan ElapsedTime { get; set; }
        public List<TimeSpan> Laps { get; set; } = new();

    }
}