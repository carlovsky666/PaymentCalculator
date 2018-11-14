using System;
using System.Collections.Generic;
using PaymentCalculator.Domain.Schedules;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    /// <summary>
    /// Factory class for buiding Schedule instances
    /// </summary>
    public class ScheduleFactory : IScheduleFactory
    {
        /// <summary>
        /// Method that retunrs a new Schedule instance
        /// </summary>
        /// <returns>The new built Schedule instance</returns>
        public ISchedule Create()
        {
            List<IValuedInterval> listRegularValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 25),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 15),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 20),
            };
            List<IValuedInterval> listExtraValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 30),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 20),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 25)
            };
            List<IBlock> blocks = new List<IBlock>()
            {
                new Block(new List<string> { "MO", "TU", "WE", "TH", "FR" }, listRegularValuedIntervals),
                new Block(new List<string> { "SA", "SU" }, listExtraValuedIntervals)
            };
            Schedule schedule = new Schedule(blocks);

            return schedule;
        }
    }
}
