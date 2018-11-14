using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    /// <summary>
    /// Factory class for buiding Employee instances
    /// </summary>
    public class EmployeeFactory : IEmployeeFactory
    {
        /// <summary>
        /// Method that retunrs a new Employee instance
        /// </summary>
        /// <param name="formatedData">The formated string that contains the data for construct the object.</param>
        /// <returns>The new built Employee instance</returns>
        public IEmployee Create(string formatedData)
        {
            string employeeName = string.Empty;
            List<IWorkedTime> workedTimes;
            string[] splittedNameAndWorkd;


            if (formatedData == null)
            {
                throw new ArgumentNullException("formatedWork parameter can`t be null.");
            }
            if (formatedData == string.Empty)
            {
                throw new ArgumentException("formatedWork parameter can`t be empty.");
            }

            splittedNameAndWorkd = GetNameAndWork(formatedData);
            employeeName = splittedNameAndWorkd[0];
            workedTimes = GetWorkedTimes(splittedNameAndWorkd[1]);
            return new Employee(employeeName, workedTimes);
        }

        private string[] GetNameAndWork(string formatedData)
        {
            string[] splittedData = formatedData.Split('=');
            if (splittedData.Count() != 2
                || splittedData[0] == string.Empty || splittedData[1] == string.Empty)
            {
                throw new ArgumentException("formatedWork parameter doesn't have a right format.");
            }

            return splittedData;
        }

        private List<IWorkedTime> GetWorkedTimes(string formatedWork)
        {
            List<IWorkedTime> workedTimes = new List<IWorkedTime>();
            string[] splittedWork = formatedWork.Split(',');
            
            foreach (string workedDay in splittedWork)
            {
                workedTimes.Add(GetWorkedDay(workedDay));
            }

            return workedTimes;
        }

        private IWorkedTime GetWorkedDay(string formatedWorkedDay)
        {
            string day;
            string formatedWorkedTime;
            TimeSpan[] times = new TimeSpan[2];

            if (formatedWorkedDay.Length != 13)
            {
                throw new ArgumentException("Any workedDay parameter doesn't have a right format.");
            }
            day = formatedWorkedDay.Substring(0, 2);
            formatedWorkedTime = formatedWorkedDay.Substring(2, 11);
            times = GetWorkedTime(formatedWorkedTime);

            return new WorkedTime(day, times[0], times[1]);

        }

        private TimeSpan[] GetWorkedTime(string formatedWorkedTime)
        {
            TimeSpan[] times = new TimeSpan[2];

            string[] splittedTime = formatedWorkedTime.Split('-');
            if (splittedTime.Count() != 2)
            {
                throw new ArgumentException("Any workedDay parameter doesn't have a right format.");
            }
            times[0] = GetTimeSpanFromString(splittedTime[0]);
            times[1] = GetTimeSpanFromString(splittedTime[1]);

            return times;

        }

        private TimeSpan GetTimeSpanFromString(string formatedTime)
        {
            string[] splittedTimeComponent = formatedTime.Split(':');

            int hours, minutes;
            if (splittedTimeComponent.Count() != 2)
            {
                throw new ArgumentException("Any workedDay parameter doesn't have a right format.");
            }
            hours = Convert.ToInt32(splittedTimeComponent[0]);
            minutes = Convert.ToInt32(splittedTimeComponent[1]);

            return new TimeSpan(hours, minutes,0);
        }

    }
     

}
