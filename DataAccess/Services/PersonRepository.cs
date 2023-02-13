using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Data;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.DataAccess.Services
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(PersonContext context) : base(context)
        {
        }


        public IEnumerable<Person> GetByName(string name)
        {
            return EntitySet.Where(x => x.Name.Equals(name));
        }

    }
}