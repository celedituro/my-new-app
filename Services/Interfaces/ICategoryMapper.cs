using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Services.Interfaces
{
    public interface ICategoryMapper
    {
        String Map(DateOnly birth);
    }
}