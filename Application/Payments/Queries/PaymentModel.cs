namespace PaymentCalculator.Application.Payments.Queries
{
    /// <summary>
    /// Class that implements the structure for the payment data.
    /// </summary>
    public class PaymentModel
    {
        public string Name { get; }
        public float Payment { get; }

        /// <summary>
        /// Constructor of the PaymentModel class.
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <param name="payment">Calculated payment</param>
        public PaymentModel(string name, float payment)
        {
            Name = name;
            Payment = payment;
        }
        
    }
}
