using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.DataAccess.Interfaces;

namespace my_new_app.DataAccess.Services
{
    [NotMapped]
    public class CategoryMapper : ICategoryMapper
    {
        public const int CHILD_AGE_MAX = 10;
        public const int TEEN_AGE_MAX = 17;
        public const int ADULT_AGE_MAX = 79;
        public const String CHILD = "Niño";
        public const String TEEN = "Adolescente";
        public const String ADULT = "Adulto";
        public const String OCTOGENARIAN = "Octogenario";

        private AgeCalculator calculator;
        public CategoryMapper(AgeCalculator calculator)
        {
            this.calculator = calculator;
        }

        public String Map(DateOnly birth)
        {
            int age = this.calculator.Calculate(birth);
            if(age <= CHILD_AGE_MAX)
            {
                return CHILD;
            } else if(age > CHILD_AGE_MAX && age <= TEEN_AGE_MAX)
            {
                return TEEN;
            } else if(age > TEEN_AGE_MAX && age <= ADULT_AGE_MAX)
            {
                return ADULT;
            } else 
            {
                return OCTOGENARIAN;
            }
        }
    }
}