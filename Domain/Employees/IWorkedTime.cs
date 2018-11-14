using PaymentCalculator.Domain.Shared;

namespace PaymentCalculator.Domain.Employees
{
    public interface IWorkedTime: ITimeInterval
    {
        string Day { get; }
    }
}