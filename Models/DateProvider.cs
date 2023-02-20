using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Models
{
    public class DateProvider
    {
        public virtual DateTime Today { get; } = DateTime.Now;
    }
}