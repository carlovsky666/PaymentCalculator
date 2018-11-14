using PaymentCalculator.Application.Payments.Queries.Factories;
using PaymentCalculator.Domain.Employees;
using PaymentCalculator.Domain.Schedules;

namespace PaymentCalculator.Application.Payments.Queries
{
    /// <summary>
    /// Class that implements the aplication logic for calculate the payment.
    /// </summary>
    public class GetPaymentForEmployeeQuery : IGetPaymentForEmployeeQuery
    {
        private readonly IScheduleFactory _scheduleFactory;
        private readonly IEmployeeFactory _employeeFactory;

        /// <summary>
        /// Constructor for the Class GetPaymentForEmployeeQuery
        /// </summary>
        /// <param name="employeeFactory">Factory for buildig the employee</param>
        /// <param name="scheduleFactory">Factory for buildig the schedule</param>
        public GetPaymentForEmployeeQuery(IEmployeeFactory employeeFactory
            ,IScheduleFactory scheduleFactory)
        {
            _employeeFactory = employeeFactory;
            _scheduleFactory = scheduleFactory;
        }

        /// <summary>
        /// Method that execute the aplication logic for calculating the payment.
        /// </summary>
        /// <param name="formantedData">The formated data that includes the informatión abuto the employee and the worked time.</param>
        /// <returns></returns>
        public PaymentModel Execute(string formantedData)
        {
            IEmployee employee = _employeeFactory.Create(formantedData);
            ISchedule schedule = _scheduleFactory.Create();
            float payment = schedule.CalculatePayment(employee);
            return new PaymentModel(employee.Name, payment);
        }
    }
}
