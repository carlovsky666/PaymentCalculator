using System.Collections.Generic;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Domain.Schedules
{
    public interface IBlock
    {
        List<string> ListDays { get; }
        List<IValuedInterval> ListValuedIntervals { get; }

        float CalculatePaymentForMatchedDays(List<IWorkedTime> listWorkedInterval);
    }
}