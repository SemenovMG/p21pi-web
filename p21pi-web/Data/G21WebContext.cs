using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using p21pi_web.Entities;

namespace p21pi_web.Data
{
    public class G21WebContext :  IdentityDbContext<UniversityUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }

        public G21WebContext(DbContextOptions<G21WebContext> o) 
            : base(o) { }
    }
}
