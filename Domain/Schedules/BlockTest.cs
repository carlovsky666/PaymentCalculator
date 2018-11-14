using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PaymentCalculator.Domain.Employees;

namespace PaymentCalculator.Domain.Schedules
{
    [TestFixture]
    public class BlockTest
    {
        [Test]
        public void OnCreatingBlock_WithNullListDay_ThrowsException()
        {
            //Arrange
            var mock = new Mock<IValuedInterval>();
            mock.Setup(mk => mk.Value).Returns(12);
            mock.Setup(mk => mk.From).Returns(new TimeSpan());
            mock.Setup(mk => mk.To).Returns(new TimeSpan());


            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Block(null,
                                new List<IValuedInterval>() { mock.Object })
                );
        }
        [Test]
        public void OnCreatingBlock_WithNullListValuedIntervals_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Block(new List<string>() { "MO", "TU" }, null)
                );
        }
        [Test]
        public void OnCreatingBlock_WithEmptyListDay_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Block(null,
                                new List<IValuedInterval>())
                );
        }
        [Test]
        public void OnCreatingBlock_WithEmptyListValuedIntervals_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Block(new List<string>(), null)
                );
        }
        [Test]
        public void OnCreatingBlock_WithCrossedIntervals_ThrowsException()
        {
            //Arrange
            var mock1 = new Mock<IValuedInterval>();
            var mock2 = new Mock<IValuedInterval>();
            var mock3 = new Mock<IValuedInterval>();
            var mock4 = new Mock<IValuedInterval>();
            mock1.Setup(mk => mk.Value).Returns(30);
            mock1.Setup(mk => mk.From).Returns(new TimeSpan(0, 0, 0));
            mock1.Setup(mk => mk.To).Returns(new TimeSpan(9, 0, 0));
            mock2.Setup(mk => mk.Value).Returns(20);
            mock2.Setup(mk => mk.From).Returns(new TimeSpan(9, 0, 0));
            mock2.Setup(mk => mk.To).Returns(new TimeSpan(18, 0, 0));
            mock3.Setup(mk => mk.Value).Returns(25);
            mock3.Setup(mk => mk.From).Returns(new TimeSpan(18, 0, 0));
            mock3.Setup(mk => mk.To).Returns(new TimeSpan(0, 0, 0));
            mock4.Setup(mk => mk.Value).Returns(30);
            mock4.Setup(mk => mk.From).Returns(new TimeSpan(12, 0, 0));
            mock4.Setup(mk => mk.To).Returns(new TimeSpan(17, 0, 0));

            //Assert
            Assert.Throws<ArgumentException>(() => new Block(new List<string>() { "MO" }, new List<IValuedInterval>() { mock1.Object, mock2.Object, mock3.Object, mock4.Object }));
        }
        [Test]
        public void AddValuedInterval_WhenIntervalsDontCross_AddIntervals()
        {
            //Arrange
            Block day;
            var mock1 = new Mock<IValuedInterval>();
            var mock2 = new Mock<IValuedInterval>();
            var mock3 = new Mock<IValuedInterval>();

            mock1.Setup(mk => mk.Value).Returns(30);
            mock1.Setup(mk => mk.From).Returns(new TimeSpan(0, 0, 0));
            mock1.Setup(mk => mk.To).Returns(new TimeSpan(9, 0, 0));
            mock2.Setup(mk => mk.Value).Returns(20);
            mock2.Setup(mk => mk.From).Returns(new TimeSpan(9, 0, 0));
            mock2.Setup(mk => mk.To).Returns(new TimeSpan(18, 0, 0));
            mock3.Setup(mk => mk.Value).Returns(25);
            mock3.Setup(mk => mk.From).Returns(new TimeSpan(18, 0, 0));
            mock3.Setup(mk => mk.To).Returns(new TimeSpan(0, 0, 0));


            //Act
            day = new Block(new List<string>() { "MO" }, new List<IValuedInterval>() { mock1.Object, mock2.Object, mock3.Object});


            //Asert
            Assert.IsInstanceOf<Block>(day);
            Assert.AreEqual(3, day.ListValuedIntervals.Count);
            Assert.AreEqual(1, day.ListDays.Count);
        }
        [Test]
        public void CalculatePayment_WhenMatch_ReturnValue()
        {

            //Arrange
            Block regularBlock;
            Block extraBlock;
            var mockValuedInterval1 = new Mock<IValuedInterval>();
            var mockValuedInterval2 = new Mock<IValuedInterval>();
            var mockValuedInterval3 = new Mock<IValuedInterval>();
            var mockValuedInterval4 = new Mock<IValuedInterval>();
            var mockValuedInterval5 = new Mock<IValuedInterval>();
            var mockValuedInterval6 = new Mock<IValuedInterval>();
            var mockWorkedTime1 = new Mock<IWorkedTime>();
            var mockWorkedTime2 = new Mock<IWorkedTime>();
            var mockWorkedTime3 = new Mock<IWorkedTime>();
            var mockWorkedTime4 = new Mock<IWorkedTime>();
            var mockWorkedTime5 = new Mock<IWorkedTime>();

            mockValuedInterval1.Setup(mk => mk.Value).Returns(25);
            mockValuedInterval1.Setup(mk => mk.From).Returns(new TimeSpan(0, 0, 0));
            mockValuedInterval1.Setup(mk => mk.To).Returns(new TimeSpan(9, 0, 0));
            mockValuedInterval2.Setup(mk => mk.Value).Returns(15);
            mockValuedInterval2.Setup(mk => mk.From).Returns(new TimeSpan(9, 0, 0));
            mockValuedInterval2.Setup(mk => mk.To).Returns(new TimeSpan(18, 0, 0));
            mockValuedInterval3.Setup(mk => mk.Value).Returns(20);
            mockValuedInterval3.Setup(mk => mk.From).Returns(new TimeSpan(18, 0, 0));
            mockValuedInterval3.Setup(mk => mk.To).Returns(new TimeSpan(0, 0, 0));
            mockValuedInterval4.Setup(mk => mk.Value).Returns(30);
            mockValuedInterval4.Setup(mk => mk.From).Returns(new TimeSpan(0, 0, 0));
            mockValuedInterval4.Setup(mk => mk.To).Returns(new TimeSpan(9, 0, 0));
            mockValuedInterval5.Setup(mk => mk.Value).Returns(20);
            mockValuedInterval5.Setup(mk => mk.From).Returns(new TimeSpan(9, 0, 0));
            mockValuedInterval5.Setup(mk => mk.To).Returns(new TimeSpan(18, 0, 0));
            mockValuedInterval6.Setup(mk => mk.Value).Returns(25);
            mockValuedInterval6.Setup(mk => mk.From).Returns(new TimeSpan(18, 0, 0));
            mockValuedInterval6.Setup(mk => mk.To).Returns(new TimeSpan(0, 0, 0));

            mockWorkedTime1.Setup(mk => mk.Day).Returns("MO");
            mockWorkedTime1.Setup(mk => mk.From).Returns(new TimeSpan(10, 0, 0));
            mockWorkedTime1.Setup(mk => mk.To).Returns(new TimeSpan(12, 0, 0));
            mockWorkedTime2.Setup(mk => mk.Day).Returns("TU");
            mockWorkedTime2.Setup(mk => mk.From).Returns(new TimeSpan(10, 0, 0));
            mockWorkedTime2.Setup(mk => mk.To).Returns(new TimeSpan(12, 0, 0));
            mockWorkedTime3.Setup(mk => mk.Day).Returns("TH");
            mockWorkedTime3.Setup(mk => mk.From).Returns(new TimeSpan(1, 0, 0));
            mockWorkedTime3.Setup(mk => mk.To).Returns(new TimeSpan(3, 0, 0));
            mockWorkedTime4.Setup(mk => mk.Day).Returns("SA");
            mockWorkedTime4.Setup(mk => mk.From).Returns(new TimeSpan(14, 0, 0));
            mockWorkedTime4.Setup(mk => mk.To).Returns(new TimeSpan(18, 0, 0));
            mockWorkedTime5.Setup(mk => mk.Day).Returns("SU");
            mockWorkedTime5.Setup(mk => mk.From).Returns(new TimeSpan(20, 0, 0));
            mockWorkedTime5.Setup(mk => mk.To).Returns(new TimeSpan(21, 0, 0));

            float regularPayment = 0;
            float extraPayment = 0;

            //Act
            regularBlock = new Block(new List<string> { "MO", "TU", "WE", "TH", "FR" }, new List<IValuedInterval>() { mockValuedInterval1.Object, mockValuedInterval2.Object, mockValuedInterval3.Object });
            extraBlock = new Block(new List<string> { "SA", "SU" }, new List<IValuedInterval>() { mockValuedInterval4.Object, mockValuedInterval5.Object, mockValuedInterval6.Object });

            regularPayment = regularBlock.CalculatePaymentForMatchedDays(new List<IWorkedTime>() { mockWorkedTime1.Object, mockWorkedTime2.Object, mockWorkedTime3.Object, mockWorkedTime4.Object, mockWorkedTime5.Object });
            extraPayment = extraBlock.CalculatePaymentForMatchedDays(new List<IWorkedTime>() { mockWorkedTime1.Object, mockWorkedTime2.Object, mockWorkedTime3.Object, mockWorkedTime4.Object, mockWorkedTime5.Object });

            //Assert
            Assert.AreEqual(110, regularPayment);
            Assert.AreEqual(105, extraPayment);
        }
        

    }
}
