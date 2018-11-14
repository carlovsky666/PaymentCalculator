using System.Collections.Generic;
using PaymentCalculator.Domain.Shared;

namespace PaymentCalculator.Domain.Schedules
{
    public interface IValuedInterval: ITimeInterval
    {
        int Value { get; }

        //float GetPaymentForMatchedTime(List<ITimeInterval> listInterval);
    }
}