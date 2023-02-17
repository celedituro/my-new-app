using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Models;
using Xunit;

namespace Tests
{
    public class CategoryFactoryTest
    {
        [Fact]
        public void ChildCategoryTest()
        {
            DateTime birth = new DateTime(2022,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Niño", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void TeenCategoryTest()
        {
            DateTime birth = new DateTime(2006,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Adolescente", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void AdultCategoryTest()
        {
            DateTime birth = new DateTime(1974,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Adulto", factory.CreateCategory(birth).Name);
        }

        [Fact]
        public void OctogenarianCategoryTest()
        {
            DateTime birth = new DateTime(1930,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            
            Assert.Equal("Octogenario", factory.CreateCategory(birth).Name);
        }
    }
}