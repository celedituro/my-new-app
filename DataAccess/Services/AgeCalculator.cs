using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.DataAccess.Services
{
    [NotMapped]
    public class AgeCalculator : IAgeCalculator
    {   
        public DateTime Today { get; }

        public AgeCalculator(DateProvider dateProvider)
        {
            this.Today = dateProvider.Today;
        }

        public int Calculate(DateOnly birth)
        {
            int age = this.Today.Year - birth.Year;
            if (this.Today.Month < birth.Month || ((this.Today.Month == birth.Month) && (this.Today.Day < birth.Day)))
            {
                age--;
            }

            return age;
        }
    }
}