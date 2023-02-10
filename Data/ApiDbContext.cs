using Microsoft.EntityFrameworkCore;
using my_new_app.Models;

namespace my_new_app.Data
{
    public class ApiDbContext: DbContext
    {   
        public virtual DbSet<Person> People { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {
            
        }
    }
}