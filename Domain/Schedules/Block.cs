using System;
using System.Collections.Generic;
using System.Linq;
using PaymentCalculator.Domain.Employees;
using PaymentCalculator.Domain.Shared;

namespace PaymentCalculator.Domain.Schedules
{
    /// <summary>
    /// Class that represents set of days with the same time structure and value per hour.
    /// </summary>
    public class Block : IBlock
    {
        public List<string> ListDays { get; }

        public List<IValuedInterval> ListValuedIntervals { get; }

        /// <summary>
        /// Constructor for the Block class.
        /// </summary>
        /// <param name="listDays">A list of days with the same time structure and value per hour. </param>
        /// <param name="listValuedIntervals">A list of IValuedIntervals for the set of days.</param>
        public Block(List<string> listDays, List<IValuedInterval> listValuedIntervals)
        {
            ListDays = listDays ?? throw new ArgumentNullException();
            ListValuedIntervals = listValuedIntervals ?? throw new ArgumentNullException();
            ValidateIntervals();
        }

        /// <summary>
        /// Method that calculate the payment and return the value.
        /// </summary>
        /// <param name="listWorkedInterval"> A list of WorkedTime.</param>
        /// <returns>The value calculate matching the ValuedIntervals and the WorkedTime</returns>
        public float CalculatePaymentForMatchedDays(List<IWorkedTime> listWorkedInterval)
        {
            List<ITimeInterval> coincidentWordekInterval = listWorkedInterval
                .Where(a => ListDays.Any(b => string.Compare((a as IWorkedTime).Day, b, true) == 0))
                .Select(x => new TimeInterval((x as ITimeInterval).From, (x as ITimeInterval).To)).ToList<ITimeInterval>();
            return ListValuedIntervals.Sum(x => GetPaymentForMatchedTime(coincidentWordekInterval, x));
        }

        private void ValidateIntervals()
        {
            if (ListValuedIntervals.Count() == 0)
            {
                throw new ArgumentException("The list of ValuedIntervals is empty.");
            }
            foreach (IValuedInterval valuedInterval in ListValuedIntervals)
            {
                if (ListValuedIntervals.Where(x => (x!= valuedInterval) && (GetMatchedTime(valuedInterval,x).TotalMinutes > 1)).Count() > 0)
                {
                    throw new ArgumentException("The list of ValuedIntervals contains one or more ValuedIntervals with with values that crosss.");
                }
            }
        }

        private void ValidateDays()
        {
            if (ListValuedIntervals.Count() == 0)
            {
                throw new ArgumentException("The list of days is empty.");
            }
            if (ListDays.GroupBy(x => x)
                    .Where(group => group.Count() > 1)
                    .Count() > 0)
            {
                throw new ArgumentException("The list of days contains one or more repeated value.");
            }
        }

        private TimeSpan GetMatchedTime(ITimeInterval firstInterval, ITimeInterval SecondInterval)
        {
            TimeSpan firstIntervalTo = (firstInterval.To==TimeSpan.Zero? new TimeSpan(24, 0, 0): firstInterval.To);
            TimeSpan secondIntervalTo = (SecondInterval.To == TimeSpan.Zero ? new TimeSpan(24, 0, 0) : SecondInterval.To);

            TimeSpan from = (firstInterval.From > SecondInterval.From ? firstInterval.From : SecondInterval.From);
            TimeSpan to = (firstIntervalTo < secondIntervalTo ? firstIntervalTo : secondIntervalTo);

            TimeSpan intersection = to - from;
            if (intersection < TimeSpan.Zero)
            {
                intersection = TimeSpan.Zero;
            }
            return intersection;
        }

        private float GetPaymentForMatchedTime(List<ITimeInterval> listInterval,IValuedInterval valuedInterval)
        {
            TimeSpan intersection;
            float daysPayment;
            float hoursPayment;
            float minutesPayment;
            float total = 0;
            foreach (ITimeInterval workedInterval in listInterval)
            {
                intersection = GetMatchedTime(workedInterval, valuedInterval);
                daysPayment = valuedInterval.Value * intersection.Days * 24;
                hoursPayment = valuedInterval.Value * intersection.Hours;
                minutesPayment = (intersection.Minutes * valuedInterval.Value) / (float)60.0;
                total = total + daysPayment + hoursPayment + minutesPayment;
            }
            return total;

        }
    }
}
