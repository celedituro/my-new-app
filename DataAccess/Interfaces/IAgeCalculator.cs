using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.DataAccess.Interfaces
{
    public interface IAgeCalculator
    {
        int Calculate(DateOnly birth);
    }
}