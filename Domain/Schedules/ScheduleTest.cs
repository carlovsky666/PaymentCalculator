using System;
using System.Collections.Generic;
using NUnit.Framework;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Domain.Schedules
{
    [TestFixture]
    public class ScheduleTest
    {
        [Test]
        public void OnCreatingSchedule_WithRightListBlock_CreateInstance()
        {
            //Arrange
            List<IValuedInterval> listRegularValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 25),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 15),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 20),
            };
            List<IValuedInterval> listExtraValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 30),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 20),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 25)
            };
            List<IBlock> blocks = new List<IBlock>()
            {
                new Block(new List<string> { "MO", "TU", "WE", "TH", "FR" }, listRegularValuedIntervals),
                new Block(new List<string> { "SA", "SU" }, listExtraValuedIntervals)
            };

            //Act
            Schedule schedule = new Schedule(blocks);

            //Assert
            Assert.IsInstanceOf<Schedule>(schedule);
            Assert.AreEqual(2, schedule.ListBlock.Count);
        }

        [Test]
        public void OnCreatingSchedule_WithNullListBlock_ThrowsException()
        {
            //Arrange
            List<IBlock> blocks = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Schedule(blocks));
        }

        [Test]
        public void OnCreatingSchedule_WithEmptyBlock_ThrowsException()
        {
            //Arrange
            List<IBlock> blocks = new List<IBlock>();

            //Assert
            Assert.Throws<ArgumentException>(() => new Schedule(blocks));
        }

        [Test]
        public void CalculatePayment_WhenInvoke_GetResult()
        {
            //Arrange
            List<IValuedInterval> listRegularValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 25),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 15),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 20),
            };
            List<IValuedInterval> listExtraValuedIntervals = new List<IValuedInterval>()
            {
                new ValuedInterval(new TimeSpan(0, 0, 0), (new TimeSpan(9, 0, 0)), 30),
                new ValuedInterval(new TimeSpan(9, 0, 0), (new TimeSpan(18, 0, 0)), 20),
                new ValuedInterval(new TimeSpan(18, 0, 0), (new TimeSpan(0, 0, 0)), 25)
            };
            List<IBlock> blocks = new List<IBlock>()
            {
                new Block(new List<string> { "MO", "TU", "WE", "TH", "FR" }, listRegularValuedIntervals),
                new Block(new List<string> { "SA", "SU" }, listExtraValuedIntervals)
            };
            Schedule schedule = new Schedule(blocks);

            List<IWorkedTime> listWorkedIntervals = new List<IWorkedTime>()
            {
                new WorkedTime("MO", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TU", new TimeSpan(10, 0, 0), (new TimeSpan(12, 0, 0))),//30
                new WorkedTime("TH", new TimeSpan(1, 0, 0), (new TimeSpan(3, 0, 0))),//50
                new WorkedTime("SA", new TimeSpan(14, 0, 0), (new TimeSpan(18, 0, 0))),//80
                new WorkedTime("SU", new TimeSpan(20, 0, 0), (new TimeSpan(21, 0, 0)))//25
            };
            string employeeName = "CARLOS";
            Employee employee = new Employee(employeeName, listWorkedIntervals);

            //Act

            float result = schedule.CalculatePayment(employee);

            //Assert
            Assert.AreEqual(215, result);

        }

    }
}
