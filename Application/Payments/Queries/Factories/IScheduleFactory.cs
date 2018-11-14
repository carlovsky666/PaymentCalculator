using PaymentCalculator.Domain.Schedules;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    public interface IScheduleFactory
    {
        ISchedule Create();
    }
}