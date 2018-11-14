using System;
using PaymentCalculator.Domain.Shared;

namespace PaymentCalculator.Domain.Employees
{
    /// <summary>
    /// Class that represents a lapse of worked time.
    /// </summary>
    public class WorkedTime : TimeInterval, IWorkedTime
    {
        public string Day { get; }

        /// <summary>
        /// Constructor of the WorkedTime class
        /// </summary>
        /// <param name="day">Worked day</param>
        /// <param name="from">Start time.</param>
        /// <param name="to">End time</param>
        public WorkedTime (string day, TimeSpan from, TimeSpan to) : base(from, to)
        {
            Day = day ?? throw new ArgumentNullException("The day parameter can`t be null.");
            if(day == string.Empty)
            {
                throw new ArgumentException("The day parameter can`t be empty.");
            }
        }
    }
}
