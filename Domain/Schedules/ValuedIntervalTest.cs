using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace PaymentCalculator.Domain.Schedules
{
    [TestFixture]
    public class ValuedIntervalTest
    {
        [TestCase(5, 0, 10, 0,-1)]
        [TestCase(5, 0, 10, 0, 0)]
        public void OnCreatingValuedInterval_WithWrongValue_ThrowsException(int fromHour, int fromMinute, int toHour, int toMinute, int value)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ValuedInterval(new TimeSpan(fromHour, fromMinute, 0), (new TimeSpan(toHour, toMinute, 0)),value));
        }

        [TestCase(5, 0, 10, 0, 20)]
        public void OnCreatingValuedInterval_WithRightValue_ReturnsObject(int fromHour, int fromMinute, int toHour, int toMinute, int value)
        {
            //Arrange
            ValuedInterval valuedInterval;

            //Act
            valuedInterval = new ValuedInterval(new TimeSpan(fromHour, fromMinute, 0), (new TimeSpan(toHour, toMinute, 0)),value);

            //Assert
            Assert.IsNotNull(valuedInterval);
        }

        /* 
        [Test]
        public void GetPayment_WhenIntervalsIntersect_ReturnValue()
        {
            //Arrange
            ValuedInterval valuedInterval;

            //Act
            valuedInterval = new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 25);

            var mock = new Mock<IWorkedTime>();
            mock.Setup(mk => mk.Day).Returns("MO");
            mock.Setup(mk => mk.From).Returns(new TimeSpan(4, 30, 0));
            mock.Setup(mk => mk.To).Returns(new TimeSpan(14, 0, 0));
            
            //Arrange
            Assert.AreEqual(112.5, valuedInterval.GetPaymentForMatchedTime(new List<ITimeInterval>() { mock.Object }));
        }

        [Test]
        public void GetPayment_WhenIntervalsDontIntersect_ReturnZero()
        {
            //Arrange
            ValuedInterval valuedInterval;

            //Act
            valuedInterval = new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 25);
            var mock = new Mock<IWorkedTime>();
            mock.Setup(mk => mk.Day).Returns("MO");
            mock.Setup(mk => mk.From).Returns(new TimeSpan(15, 30, 0));
            mock.Setup(mk => mk.To).Returns(new TimeSpan(17, 0, 0));

            //Arrange
            Assert.AreEqual(0, valuedInterval.GetPaymentForMatchedTime(new List<ITimeInterval>() { mock.Object }));
        }
        */
    }
}
