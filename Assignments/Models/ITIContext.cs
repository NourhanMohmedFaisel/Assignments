using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Models
{
    public class ITIContext: IdentityDbContext<ApplicationUser>
    {


        public ITIContext() :base()
        {

        }
        public ITIContext(DbContextOptions<ITIContext> options) : base(options) { }
        public DbSet<Instractor> Instractor { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Trainee> Trainee { get; set; }

        public DbSet<CrsResult> CrsResult { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=LAPTOP-GGKMQL0S;Initial Catalog=University;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
