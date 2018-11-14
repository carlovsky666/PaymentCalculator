using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    public interface IEmployeeFactory
    {
        IEmployee Create(string formatedWork);
    }
}