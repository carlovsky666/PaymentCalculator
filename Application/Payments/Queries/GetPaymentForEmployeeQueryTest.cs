using Moq;
using NUnit.Framework;
using PaymentCalculator.Domain.Employees;
using PaymentCalculator.Domain.Schedules;

namespace PaymentCalculator.Application.Payments.Queries.Factories
{
    [TestFixture]
    public class GetPaymentForEmployeeTest
    {
        [Test]
        public void Execute_WhenInvokes_CreateEmployee()
        {
            //Arrange
            string formatedData = "data";
            var mockEmployeeFactory = new Mock<IEmployeeFactory>();
            var mockEmployee = new Mock<IEmployee>();
            mockEmployeeFactory.Setup(p => p.Create(formatedData)).Returns(mockEmployee.Object);
            var mockScheduleFactory = new Mock<IScheduleFactory>();
            var mockSchedule = new Mock<ISchedule>();
            mockScheduleFactory.Setup(p => p.Create()).Returns(mockSchedule.Object);

            IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery = new GetPaymentForEmployeeQuery(mockEmployeeFactory.Object, mockScheduleFactory.Object);

            //Act
            getPaymentForEmployeeQuery.Execute(formatedData);

            //Assert
            mockEmployeeFactory
                .Verify(p => p.Create(formatedData), Times.Once);
        }

        [Test]
        public void Execute_WhenInvokes_CreateSchedule()
        {
            //Arrange
            string formatedData = "data";
            var mockEmployeeFactory = new Mock<IEmployeeFactory>();
            var mockEmployee = new Mock<IEmployee>();
            mockEmployeeFactory.Setup(p => p.Create(formatedData)).Returns(mockEmployee.Object);
            var mockScheduleFactory = new Mock<IScheduleFactory>();
            var mockSchedule = new Mock<ISchedule>();
            mockScheduleFactory.Setup(p => p.Create()).Returns(mockSchedule.Object);

            IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery = new GetPaymentForEmployeeQuery(mockEmployeeFactory.Object, mockScheduleFactory.Object);

            //Act
            getPaymentForEmployeeQuery.Execute(formatedData);

            //Assert
            mockScheduleFactory
                .Verify(p => p.Create(), Times.Once);
        }

        [Test]
        public void Execute_WhenInvokes_ExecuteCalculatePayment()
        {
            //Arrange
            string formatedData = "data";
            var mockEmployeeFactory = new Mock<IEmployeeFactory>();
            var mockEmployee = new Mock<IEmployee>();
            mockEmployeeFactory.Setup(p => p.Create(formatedData)).Returns(mockEmployee.Object);
            var mockScheduleFactory = new Mock<IScheduleFactory>();
            var mockSchedule = new Mock<ISchedule>();
            mockScheduleFactory.Setup(p => p.Create()).Returns(mockSchedule.Object);
            mockSchedule.Setup(p => p.CalculatePayment(mockEmployee.Object)).Returns(10);
            IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery = new GetPaymentForEmployeeQuery(mockEmployeeFactory.Object, mockScheduleFactory.Object);

            //Act
            getPaymentForEmployeeQuery.Execute(formatedData);

            //Assert
            mockSchedule
                .Verify(p => p.CalculatePayment(mockEmployee.Object), Times.Once);
        }

        [Test]
        public void Execute_WhenInvokes_RetunrPayment()
        {
            //Arrange
            string formatedData = "data";
            var mockEmployeeFactory = new Mock<IEmployeeFactory>();
            var mockEmployee = new Mock<IEmployee>();
            mockEmployeeFactory.Setup(p => p.Create(formatedData)).Returns(mockEmployee.Object);
            mockEmployee.Setup(p => p.Name).Returns("Carlos");
            var mockScheduleFactory = new Mock<IScheduleFactory>();
            var mockSchedule = new Mock<ISchedule>();
            mockScheduleFactory.Setup(p => p.Create()).Returns(mockSchedule.Object);
            mockSchedule.Setup(p => p.CalculatePayment(mockEmployee.Object)).Returns(10);
            IGetPaymentForEmployeeQuery getPaymentForEmployeeQuery = new GetPaymentForEmployeeQuery(mockEmployeeFactory.Object, mockScheduleFactory.Object);
            PaymentModel payment;

            //Act
            payment = getPaymentForEmployeeQuery.Execute(formatedData);

            //Assert
            Assert.IsNotNull(payment);
            Assert.AreEqual("Carlos", payment.Name);
            Assert.AreEqual(10, payment.Payment);
        }
    }
}
