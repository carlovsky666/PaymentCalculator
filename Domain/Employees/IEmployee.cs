using System.Collections.Generic;

namespace PaymentCalculator.Domain.Employees
{
    public interface IEmployee
    {
        string Name { get; }
        List<IWorkedTime> WorkedIntervals { get; }
    }
}