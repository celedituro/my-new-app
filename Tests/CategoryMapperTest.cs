using Moq;
using my_new_app.Models;
using my_new_app.Services;

namespace Tests
{
    public class CategoryMapperTest
    {
        [Fact]
        public void ChildTest()
        {   
            DateOnly birth = new DateOnly(2022,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            
            Assert.Equal("Niño", mapper.Map(birth));
        }

        [Fact]
        public void TeenTest()
        {   
            DateOnly birth = new DateOnly(2006,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            
            Assert.Equal("Adolescente", mapper.Map(birth));
        }

        [Fact]
        public void AdultTest()
        {   
            DateOnly birth = new DateOnly(1974,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            
            Assert.Equal("Adulto", mapper.Map(birth));
        }

        [Fact]
        public void OctogenarianTest()
        {   
            DateOnly birth = new DateOnly(1930,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            
            Assert.Equal("Octogenario", mapper.Map(birth));
        }
    }
}