using System.Collections.Generic;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Domain.Schedules
{
    public interface ISchedule
    {
        List<IBlock> ListBlock { get; }

        float CalculatePayment(IEmployee employee);
    }
}