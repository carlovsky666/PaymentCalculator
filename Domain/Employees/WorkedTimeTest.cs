using System;
using NUnit.Framework;

namespace PaymentCalculator.Domain.Employees
{
    [TestFixture]
    public class WorkedTimeTest
    {
        [Test]
        public void OnCreatingWorkedInterval_WithNullDay_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new WorkedTime(null, new TimeSpan(5, 0, 0), (new TimeSpan(10, 0, 0))));
        }

        [Test]
        public void OnCreatingWorkedInterval_WithEmptyDay_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new WorkedTime("", new TimeSpan(5, 0, 0), (new TimeSpan(10, 0, 0))));
        }

        [Test]
        public void OnCreatingWorkedInterval_WithCorrectData_ReturnsObject()
        {
            //Arrange
            IWorkedTime workedInterval;

            //Act
            workedInterval = new WorkedTime("MO", new TimeSpan(5, 0, 0), new TimeSpan(10, 0, 0));

            //Assert
            Assert.IsInstanceOf<IWorkedTime>(workedInterval);
            Assert.AreEqual("MO", workedInterval.Day);
            Assert.AreEqual(5, workedInterval.From.Hours);
            Assert.AreEqual(0, workedInterval.From.Minutes);
            Assert.AreEqual(10, workedInterval.To.Hours);
            Assert.AreEqual(0, workedInterval.To.Minutes);
        }

    }
}
