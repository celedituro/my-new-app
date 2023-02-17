using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Models;
using Xunit;

namespace Tests
{
    public class AgeCalculatorTest
    {
        [Fact]
        public void Test1()
        {   
            DateOnly birth = new DateOnly(2000,03,30);
            AgeCalculator calculator = new AgeCalculator();
            int ageCalculated = calculator.Calculate(birth);
            int ageExpected = 22;
            Assert.Equal(ageExpected, ageCalculated);
        }

        [Fact]
        public void Test2()
        {   
            DateOnly birth = new DateOnly(1996,02,01);
            AgeCalculator calculator = new AgeCalculator();
            int ageCalculated = calculator.Calculate(birth);
            int ageExpected = 27;
            Assert.Equal(ageExpected, ageCalculated);
        }
    }
}