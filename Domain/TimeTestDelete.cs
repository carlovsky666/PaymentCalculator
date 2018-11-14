//using System;
//using NUnit.Framework;

//namespace PaymentCalculator.Domain
//{
//    [TestFixture]
//    public class TimeTestDelete
//    {
//        [TestCase(-1, 0)]
//        [TestCase(24, 0)]
//        public void WhenCreateTime_WithHourOutOfRange_ThrowsException(int hour, int minute)
//        {
//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => new TimeDelete(hour, minute));
//        }

//        [TestCase(0, 0)]
//        [TestCase(12, 0)]
//        [TestCase(23, 0)]
//        public void WhenCreateTime_WithCorrectHour_ReturnsObject(int hour, int minute)
//        {
//            //Arrange
//            TimeDelete time;

//            //Act
//            time = new TimeDelete(hour, minute);

//            //Assert
//            Assert.IsNotNull(time);
//        }

//        [TestCase(0, -1)]
//        [TestCase(0, 60)]
//        public void WhenCreateTime__WithMinutesOutOfRange_ThrowsException(int hour, int minute)
//        {
//            //Assert
//            Assert.Throws<ArgumentOutOfRangeException>(() => new TimeDelete(hour, minute));
//        }

//        [TestCase(0, 0)]
//        [TestCase(0, 30)]
//        [TestCase(0, 59)]
//        public void WhenCreateTime_WithCorrectMinutes_ReturnsObject(int hour, int minute)
//        {
//            //Arrange
//            TimeDelete time;

//            //Act
//            time = new TimeDelete(hour, minute);

//            //Assert
//            Assert.IsNotNull(time);
//        }

//        [Test]
//        public void WhenCompareIfGreater_FirstTimeObjectGreater_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(10, 0);
//            TimeDelete secondTime = new TimeDelete(8, 0);

//            //Act
//            bool result = firstTime > secondTime;

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void WhenCompareIfGreater_FirstTimeObjectLess_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(10, 0);

//            //Act
//            bool result = firstTime > secondTime;

//            //Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void WhenCompareIfGreater_BothTimeObjectsEqual_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(8, 0);

//            //Act
//            bool result = firstTime > secondTime;

//            //Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void WhenCompareIfLess_FirstTimeObjectLess_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(10, 0);

//            //Act
//            bool result = firstTime < secondTime;

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void WhenCompareIfLess_FirstTimeObjectGreater_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete greaterTime = new TimeDelete(10, 0);
//            TimeDelete lessTime = new TimeDelete(8, 0);

//            //Act
//            bool result = greaterTime < lessTime;

//            //Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void WhenCompareIfLess_BothTimeObjectsEqual_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete greaterTime = new TimeDelete(8, 0);
//            TimeDelete lessTime = new TimeDelete(8, 0);

//            //Act
//            bool result = greaterTime < lessTime;

//            //Assert
//            Assert.IsFalse(result);
//        }


//        [Test]
//        public void WhenCompareIfGreaterOrEqual_FirstTimeObjectGreater_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(10, 0);
//            TimeDelete secondTime = new TimeDelete(8, 0);

//            //Act
//            bool result = firstTime >= secondTime;

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void WhenCompareIfGreaterOrEqual_FirstTimeObjectLess_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(10, 0);

//            //Act
//            bool result = firstTime >= secondTime;

//            //Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void WhenCompareIfGreaterOrEqual_BothTimeObjectsEqual_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(8, 0);

//            //Act
//            bool result = firstTime >= secondTime;

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void WhenCompareIfLessOrEqual_FirstTimeObjectLess_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete firstTime = new TimeDelete(8, 0);
//            TimeDelete secondTime = new TimeDelete(10, 0);

//            //Act
//            bool result = firstTime <= secondTime;

//            //Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void WhenCompareIfLessOrEqual_FirstTimeObjectGreater_ReturnFalse()
//        {
//            //Arrange
//            TimeDelete greaterTime = new TimeDelete(10, 0);
//            TimeDelete lessTime = new TimeDelete(8, 0);

//            //Act
//            bool result = greaterTime <= lessTime;

//            //Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void WhenCompareIfLessOrEqual_BothTimeObjectsEqual_ReturnTrue()
//        {
//            //Arrange
//            TimeDelete greaterTime = new TimeDelete(8, 0);
//            TimeDelete lessTime = new TimeDelete(8, 0);

//            //Act
//            bool result = greaterTime <= lessTime;

//            //Assert
//            Assert.IsTrue(result);
//        }


//        ///TODO Test for operators == and !=
//    }
//}
