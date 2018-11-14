using System;
using PaymentCalculator.Application.Payments.Queries;
using PaymentCalculator.Application.Payments.Queries.Factories;
using PaymentCalculator.Presentation;

namespace Presentation
{
    class Program
    {
        /// <summary>
        /// Main entry for the program.
        /// </summary>
        /// <param name="args">Args to send (name of the file en the same directory)</param>
        static void Main(string[] args)
        {
            IEmployeeFactory employeeFactory = new EmployeeFactory();
            IScheduleFactory scheduleFactory = new ScheduleFactory();
            IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery = new GetPaymentForEmployeeQuery(employeeFactory,scheduleFactory);
            Client client = new Client(getPaymentForEmployeeQuery);

            client.PrintCalculatedPayment(args[0]);
            Console.ReadLine();
        }


        
    }
}
