using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PaymentCalculator.Domain.Employees
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void OnCreatingEmployee_WithNullName_ThrowsException()
        {
            //Arrange
            List<IWorkedTime> listWorkedIntervals = new List<IWorkedTime>()
            {
                new WorkedTime("MO", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TU", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TH", new TimeSpan(1, 0, 0), (new TimeSpan(3, 0, 0))),//50
                new WorkedTime("SA", new TimeSpan(14, 0, 0), (new TimeSpan(18, 0, 0))),//80
                new WorkedTime("SU", new TimeSpan(20, 0, 0), (new TimeSpan(21, 0, 0)))//25
            };
            string name = null;


            //Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(name, listWorkedIntervals));
        }
        [Test]
        public void OnCreatingEmployee_WithEmptyName_ThrowsException()
        {
            //Arrange
            List<IWorkedTime> listWorkedIntervals = new List<IWorkedTime>()
            {
                new WorkedTime("MO", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TU", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TH", new TimeSpan(1, 0, 0), (new TimeSpan(3, 0, 0))),//50
                new WorkedTime("SA", new TimeSpan(14, 0, 0), (new TimeSpan(18, 0, 0))),//80
                new WorkedTime("SU", new TimeSpan(20, 0, 0), (new TimeSpan(21, 0, 0)))//25
            };
            string name = "";


            //Assert
            Assert.Throws<ArgumentException>(() => new Employee(name, listWorkedIntervals));
        }
        [Test]
        public void OnCreatingEmployee_WithNullWorkedIntervale_ThrowsException()
        {
            //Arrange
            List<IWorkedTime> listWorkedIntervals = null;
            string name = "CARLOS";


            //Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(name, listWorkedIntervals));
        }
        [Test]
        public void OnCreatingEmployee_WithEmptyWorkedIntervale_ThrowsException()
        {
            //Arrange
            List<IWorkedTime> listWorkedIntervals = new List<IWorkedTime>();
            string name = "CARLOS";


            //Assert
            Assert.Throws<ArgumentException>(() => new Employee(name, listWorkedIntervals));
        }

    }
}
