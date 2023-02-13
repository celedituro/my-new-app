using Microsoft.EntityFrameworkCore;
using my_new_app.Models;

namespace my_new_app.Data
{
    public class PersonContext: DbContext
    {   
        public virtual DbSet<Person>? People { get; set; }
        public PersonContext(DbContextOptions<PersonContext> options): base(options)
        {
            
        }
    }
}