using System;
using PaymentCalculator.Domain.Shared;

namespace PaymentCalculator.Domain.Schedules
{
    /// <summary>
    /// Class that represents a single interval of time and its value.
    /// </summary>
    public class ValuedInterval : TimeInterval, IValuedInterval
    {
        public int Value { get;}

        /// <summary>
        /// Constructor for the ValuedInterval class.
        /// </summary>
        /// <param name="from">Start time</param>
        /// <param name="to">End time</param>
        /// <param name="value">Value per hour</param>
        public ValuedInterval(TimeSpan from, TimeSpan to, int value):base(from, to)
        {
            if(value <= 0)
            {
                throw new ArgumentOutOfRangeException("value", "The value parameter must have a value greater than zero.");
            }
            Value = value;
        }
    }
}
