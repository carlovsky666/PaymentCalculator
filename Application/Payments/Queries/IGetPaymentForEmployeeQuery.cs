namespace PaymentCalculator.Application.Payments.Queries
{
    public interface IGetPaymentForEmployeeQuery
    {
        PaymentModel Execute(string formantedData);
    }
}