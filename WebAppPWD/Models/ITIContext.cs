using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppPWD.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        //Class ==< Table 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ITIContext()//
        {
            
        }
      
        public ITIContext(DbContextOptions<ITIContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebAppPWD45;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
