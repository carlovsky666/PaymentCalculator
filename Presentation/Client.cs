using System;
using System.Collections.Generic;
using System.IO;
using PaymentCalculator.Application.Payments.Queries;

namespace PaymentCalculator.Presentation
{
    /// <summary>
    /// Class that invokes the aplication objects for calculate the payment.
    /// </summary>
    public class Client
    {
        private readonly IGetPaymentForEmployeeQuery _getPaymentForEmployeeQuery;
        public Client(IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery)
        {
            _getPaymentForEmployeeQuery = getPaymentForEmployeeQuery;
        }

        /// <summary>
        /// Prints the calculated payment for the record sent in the formatedData parameter.
        /// </summary>
        /// <param name="formatedData">The string that contains the data in the right format.</param>
        public void PrintCalculatedPayment(string formatedData)
        {
            List<string> workData = new List<string>();
            PaymentModel payment;
            string filePath = @".\" + formatedData.ToString();

            try
            {
                workData = ReadFile(filePath);

                foreach (string line in workData)
                {
                    try
                    {
                        payment = _getPaymentForEmployeeQuery.Execute(line);
                        Console.WriteLine("The amount to pay " + payment.Name + " is: " + payment.Payment + " USD");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Read the file retrieve de data. 
        /// </summary>
        /// <param name="filePath">Path of the file.</param>
        /// <returns>List<string> that contains the data.</returns>
        private static List<string> ReadFile(string filePath)
        {
            List<string> workData = new List<string>();
            StreamReader reader = new StreamReader(filePath);
            string fileLine = "";

            while (fileLine != null)
            {
                fileLine = reader.ReadLine();
                if (fileLine != null)
                {
                    workData.Add(fileLine);
                }
            }
            reader.Close();

            return workData;
        }
    }
}
