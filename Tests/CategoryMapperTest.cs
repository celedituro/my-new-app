using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Models;
using Xunit;

namespace Tests
{
    public class CategoryMapperTest
    {
        [Fact]
        public void ChildTest()
        {   
            DateOnly birth = new DateOnly(2022,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);

            String name = mapper.Map(birth);
            String nameExpected = "Niño";
            
            Assert.Equal(nameExpected, name);
        }

        [Fact]
        public void TeenTest()
        {   
            DateOnly birth = new DateOnly(2006,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);

            String name = mapper.Map(birth);
            String nameExpected = "Adolescente";

            Assert.Equal(nameExpected, name);
        }

        [Fact]
        public void AdultTest()
        {   
            DateOnly birth = new DateOnly(1974,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);

            String name = mapper.Map(birth);
            String nameExpected = "Adulto";

            Assert.Equal(nameExpected, name);
        }

        [Fact]
        public void OctogenarianTest()
        {   
            DateOnly birth = new DateOnly(1930,02,01);
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);

            String name = mapper.Map(birth);
            String nameExpected = "Octogenario";

            Assert.Equal(nameExpected, name);
        }
    }
}