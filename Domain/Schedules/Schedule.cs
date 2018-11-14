using System;
using System.Collections.Generic;
using System.Linq;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Domain.Schedules
{
    /// <summary>
    /// A class that represents the valued schedule.
    /// </summary>
    public class Schedule : ISchedule
    {
        public List<IBlock> ListBlock { get; }

        /// <summary>
        /// Constructor for the Schedule class.
        /// </summary>
        /// <param name="listBlock">A list of blocks of days that make up the schedule</param>
        public Schedule(List<IBlock> listBlock)
        {
            ListBlock = listBlock?? throw new ArgumentNullException("The listBlock list cant be null");
            if(ListBlock.Count == 0)
            {
                throw new ArgumentException("The listBlock list cant be empty");
            }
        }

        /// <summary>
        /// Method that calculates the payment.
        /// </summary>
        /// <param name="employee">Employee for the calculation of the payment.</param>
        /// <returns>The value of the payment.</returns>
        public float CalculatePayment(IEmployee employee)
        {
            return ListBlock.Sum(x => x.CalculatePaymentForMatchedDays(employee.WorkedIntervals));
        }
    }
}
