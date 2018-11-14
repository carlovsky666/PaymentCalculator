using NUnit.Framework;
using PaymentCalculator.Domain.Schedules;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    [TestFixture]
    public class ScheduleFactoryTest
    {
        [Test]
        public void Create_ReturnSchedule()
        {
            //Arrange
            IScheduleFactory factory = new ScheduleFactory();

            //Act
            ISchedule schedule = factory.Create();

            //Assert
            Assert.IsInstanceOf<ISchedule>(schedule);
            Assert.AreEqual(2,schedule.ListBlock.Count);
        }
    }
}
