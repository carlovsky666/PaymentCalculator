using System;
using System.Collections.Generic;

namespace PaymentCalculator.Domain.Employees
{
    /// <summary>
    /// Class that represents to the employee and his worked time.
    /// </summary>
    public class Employee : IEmployee
    {
        public string Name { get;  }
        public List<IWorkedTime> WorkedIntervals { get; }

        /// <summary>
        /// Constructor for the Employee class
        /// </summary>
        /// <param name="name">Employee's Name</param>
        /// <param name="workedInterval">Employee's worked intervals</param>
        public Employee(string name, List<IWorkedTime> workedInterval)
        {
            Name = name ?? throw new ArgumentNullException("Parameter Name can't be null");
            WorkedIntervals = workedInterval ?? throw new ArgumentNullException("Parameter workedTime can't be null");
            if (Name == string.Empty)
            {
                throw new ArgumentException("Name can't be empty");
            }
            if (workedInterval.Count == 0)
            {
                throw new ArgumentException("Parameter workedTime can't be empty");
            }
        }
    }
}
