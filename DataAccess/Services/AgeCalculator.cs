using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.DataAccess.Interfaces;

namespace my_new_app.DataAccess.Services
{
    [NotMapped]
    public class AgeCalculator : IAgeCalculator
    {   
        public int Calculate(DateOnly birth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birth.Year;

            if (today.Month < birth.Month || ((today.Month == birth.Month) && (today.Day < birth.Day)))
            {
                age--;
            }

            return age;
        }
    }
}