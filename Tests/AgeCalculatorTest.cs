using Moq;
using my_new_app.Models;
using my_new_app.Services;
using my_new_app.Services.Interfaces;

namespace Tests
{
    public class AgeCalculatorTest
    {
        [Fact]
        public void Test1()
        {   
            DateOnly birth = new DateOnly(2000,03,30);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(22, calculator.Calculate(birth));
        }

        [Fact]
        public void Test2()
        {   
            DateOnly birth = new DateOnly(1996,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);

            Assert.Equal(27, calculator.Calculate(birth));
        }
    }
}