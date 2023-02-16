using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Models
{
    public class AgeCalculator
    {   
        public int Calculate(DateTime birth)
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