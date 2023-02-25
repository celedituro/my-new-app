using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Models;

namespace my_new_app.DataAccess.Interfaces
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> FilterByFirstOrLastName(string search);
    }
}