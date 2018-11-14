using System;
using NUnit.Framework;

namespace PaymentCalculator.Domain.Shared
{
    [TestFixture]
    public class TimeIntervalTest
    {
        [TestCase(10, 0, 8, 0)]
        [TestCase(10, 0, 10, 0)]
        [TestCase(24, 0, 1, 0)]
        [TestCase(0, 0, 24, 0)]
        public void OnCreatingInterval_WithTimeOutOfRange_ThrowsException(int fromHour, int fromMinute, int toHour, int toMinute)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new TimeInterval(new TimeSpan(fromHour,fromMinute,0), (new TimeSpan(toHour, toMinute,0))));
        }

        [TestCase(22, 0, 0, 0)]
        [TestCase(10, 0, 12, 0)]
        [TestCase(0, 0, 10, 0)]
        [TestCase(0, 0, 0, 0)]
        public void OnCreatingInterval_WithCorrectTime_ReturnsObject(int fromHour, int fromMinute, int toHour, int toMinute)
        {
            //Arrange
            TimeInterval Interval;

            //Act
            Interval = new TimeInterval(new TimeSpan(fromHour, fromMinute, 0), (new TimeSpan(toHour, toMinute, 0)));

            //Assert
            Assert.IsNotNull(Interval);
        }

        /*
        [Test]
        public void GetIntersectionTime_WhenWorkedIntervalIntersectsValuedInterval_ReturnTime()
        {
            //Arrange
            TimeInterval valuedInterval;
            TimeInterval workedInterval;
            TimeSpan matchedTime;

            //Act
            valuedInterval = new TimeInterval(new TimeSpan(0, 0, 0), (new TimeSpan(0, 0, 0)));
            workedInterval = new TimeInterval(new TimeSpan(12, 0, 0), (new TimeSpan(0, 0, 0)));
            matchedTime = valuedInterval.GetMatchedTime(workedInterval);

            //Arrange
            Assert.AreEqual(0, matchedTime.Days);
            Assert.AreEqual(12, matchedTime.Hours);
            Assert.AreEqual(0, matchedTime.Minutes);

        }

        [Test]
        public void GetIntersectionTime_WhenWorkedIntervalIsSubSetOfValuedInterval_ReturnTime()
        {
            //Arrange
            TimeInterval valuedInterval;
            TimeInterval workedInterval;
            TimeSpan matchedTime;

            //Act
            valuedInterval = new TimeInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)));
            workedInterval = new TimeInterval(new TimeSpan(2, 45, 0), (new TimeSpan(7, 25, 0)));
            matchedTime = valuedInterval.GetMatchedTime(workedInterval);

            //Arrange
            Assert.AreEqual(4, matchedTime.Hours);
            Assert.AreEqual(40, matchedTime.Minutes);

        }


        [Test]
        public void GetIntersectionTime_WhenValuedIntervalIsSubSetOfWorkedInterval_ReturnTime()
        {
            //Arrange
            TimeInterval valuedInterval;
            TimeInterval workedInterval;
            TimeSpan matchedTime;

            //Act
            valuedInterval = new TimeInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)));
            workedInterval = new TimeInterval(new TimeSpan(3, 45, 0), (new TimeSpan(20, 25, 0)));
            matchedTime = valuedInterval.GetMatchedTime(workedInterval);

            //Arrange
            Assert.AreEqual(9, matchedTime.Hours);
            Assert.AreEqual(0, matchedTime.Minutes);

        }

        [Test]
        public void GetIntersectionTime_WhenDoesntIntersectIntervals_ReturnZero()
        {
            //Arrange
            TimeInterval valuedInterval;
            TimeInterval workedInterval;
            TimeSpan matchedTime;

            //Act
            valuedInterval = new TimeInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)));
            workedInterval = new TimeInterval(new TimeSpan(12, 0, 0), (new TimeSpan(15, 0, 0)));
            matchedTime = valuedInterval.GetMatchedTime(workedInterval);

            //Arrange
            Assert.AreEqual(0, matchedTime.Hours);
            Assert.AreEqual(0, matchedTime.Minutes);

        }
        */
    }
}
