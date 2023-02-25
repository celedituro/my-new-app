using Moq;
using my_new_app.Models;
using my_new_app.Services;

namespace Tests
{
    public class CategoryFactoryTest
    {
        [Fact]
        public void MinAgeForChildCategoryTest()
        {
            DateOnly birth = new DateOnly(2023,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Niño", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MaxAgeForChildCategoryTest()
        {
            DateOnly birth = new DateOnly(2013,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Niño", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MinAgeForTeenCategoryTest()
        {
            DateOnly birth = new DateOnly(2012,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Adolescente", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MaxAgeForTeenCategoryTest()
        {
            DateOnly birth = new DateOnly(2006,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Adolescente", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MinAgeForAdultCategoryTest()
        {
            DateOnly birth = new DateOnly(2005,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Adulto", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MaxAgeForAdultCategoryTest()
        {
            DateOnly birth = new DateOnly(1944,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Adulto", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MinAgeForOctogenarianCategoryTest()
        {
            DateOnly birth = new DateOnly(1943,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Octogenario", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void MaxAgeForOctogenarianCategoryTest()
        {
            DateOnly birth = new DateOnly(1923,02,25);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,25));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Octogenario", factory.CreateCategory(birth).Name);
        }
    }
}