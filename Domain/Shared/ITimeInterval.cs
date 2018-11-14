using System;
namespace PaymentCalculator.Domain.Shared
{
    public interface ITimeInterval
    {
        TimeSpan From { get; }
        TimeSpan To { get; }

        //TimeSpan GetMatchedTime(ITimeInterval interval);
    }
}