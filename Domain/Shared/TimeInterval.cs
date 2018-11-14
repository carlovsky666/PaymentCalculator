using System;

namespace PaymentCalculator.Domain.Shared
{
    /// <summary>
    /// Class that represents a sigle interval of time.
    /// </summary>
    public class TimeInterval : ITimeInterval
    {
        public TimeSpan From { get; }
        public TimeSpan To { get; }

        /// <summary>
        /// Constructor for the TimeInterval class.
        /// </summary>
        /// <param name="from">Start time</param>
        /// <param name="to">End time</param>
        public TimeInterval(TimeSpan from, TimeSpan to)
        {
            if (from >= new TimeSpan(24, 0, 0) || to >= new TimeSpan(24, 0, 0))
            {
                throw new ArgumentOutOfRangeException("from", "Should be less than 24 hours. To represent midnight use 00:00:00");
            }

            if(to != TimeSpan.Zero && to <= from )
            {
                throw new ArgumentOutOfRangeException("From parameter must be less than To parameter");
            }
            From = from;
            To = to;
        }
    }
}
