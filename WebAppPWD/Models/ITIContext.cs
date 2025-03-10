using Microsoft.EntityFrameworkCore;

namespace WebAppPWD.Models
{
    public class ITIContext:DbContext
    {
        //Class ==< Table 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebAppPWD45;Integrated Security=True;Encrypt=False");
        }
    }
}
