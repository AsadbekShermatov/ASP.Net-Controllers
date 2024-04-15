using ASP.Net_Controllers.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_Controllers.Context
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students{ get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { } 
        
            
    
    }
}
