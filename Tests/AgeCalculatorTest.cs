using Moq;
using my_new_app.Models;
using my_new_app.Services;
using my_new_app.Services.Interfaces;

namespace Tests
{
    public class AgeCalculatorTest
    {
        [Fact]
        public void MinAgeChildTest()
        {   
            DateOnly birth = new DateOnly(2023,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(0, calculator.Calculate(birth));
        }

        [Fact]
        public void MaxAgeChildTest()
        {   
            DateOnly birth = new DateOnly(2013,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(10, calculator.Calculate(birth));
        }

        [Fact]
        public void MinAgeTeenTest()
        {   
            DateOnly birth = new DateOnly(2012,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(11, calculator.Calculate(birth));
        }

        [Fact]
        public void MaxAgeTeenTest()
        {   
            DateOnly birth = new DateOnly(2006,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(17, calculator.Calculate(birth));
        }

        [Fact]
        public void MinAgeAdultTest()
        {   
            DateOnly birth = new DateOnly(2005,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(18, calculator.Calculate(birth));
        }

        [Fact]
        public void MaxAgeAdultTest()
        {   
            DateOnly birth = new DateOnly(1944,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(79, calculator.Calculate(birth));
        }

        [Fact]
        public void MinAgeOctogenarianTest()
        {   
            DateOnly birth = new DateOnly(1943,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(80, calculator.Calculate(birth));
        }

        [Fact]
        public void MaxAgeOctogenarianTest()
        {   
            DateOnly birth = new DateOnly(1923,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(100, calculator.Calculate(birth));
        }
    }
}