using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using my_new_app.DataAccess.Services;
using my_new_app.Models;
using Xunit;

namespace Tests
{
    public class CategoryFactoryTest
    {
        [Fact]
        public void ChildCategoryTest()
        {
            DateOnly birth = new DateOnly(2022,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Niño", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void TeenCategoryTest()
        {
            DateOnly birth = new DateOnly(2006,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Adolescente", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void AdultCategoryTest()
        {
            DateOnly birth = new DateOnly(1974,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Adulto", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void OctogenarianCategoryTest()
        {
            DateOnly birth = new DateOnly(1930,02,01);
            var mock = new Mock<DateProvider>();
            mock.Setup(x => x.Today).Returns(new DateTime(2023,02,19));
            AgeCalculator calculator = new AgeCalculator(mock.Object);
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);

            Assert.Equal("Octogenario", factory.CreateCategory(birth).Name);
        }
    }
}