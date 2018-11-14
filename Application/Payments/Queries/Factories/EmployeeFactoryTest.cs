using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    [TestFixture]
    public class EmployeeFactoryTest
    {
        [Test]
        public void Create_WhenNullParameter_ThrowException()
        {
            //Arrange
            IEmployeeFactory factory = new EmployeeFactory();
            string formatedWork = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => factory.Create(formatedWork));

        }

        [TestCase("")]
        [TestCase("hola mundo")]
        [TestCase("hola=mundo=")]
        [TestCase("=")]
        [TestCase("CARLOS=")]
        [TestCase("=ALGO")]
        [TestCase("CARLOS=HOLA")]
        [TestCase("CARLOS=1234567890123")]
        [TestCase("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-3:00,SA14:00-18:00,SU20:00-21:00")]
        //[TestCase("hola mundo=algo")]
        public void Create_WhenUnformatedParameter_ThrowException(string formatedWork)
        {
            //Arrange
            IEmployeeFactory factory = new EmployeeFactory();

            //Assert
            Assert.Throws<ArgumentException>(() => factory.Create(formatedWork));

        }

        [TestCase("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00")]
        //[TestCase("hola mundo=algo")]
        public void Create_WhenFormatedParameter_CreateInstance(string formatedWork)
        {
            //Arrange
            IEmployeeFactory factory = new EmployeeFactory();

            //Act
            IEmployee employee = factory.Create(formatedWork);

            //Assert
            Assert.IsInstanceOf<IEmployee>(employee);
            Assert.AreEqual("RENE", employee.Name);
            Assert.IsNotNull(employee.WorkedIntervals);
            Assert.AreEqual(5, employee.WorkedIntervals.Count);

        }
    }
}
