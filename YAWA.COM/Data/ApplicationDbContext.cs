using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YAWA.Data;

namespace YAWA.COM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<LessonPlanner> LessonPlanners { get; set; }
        public virtual DbSet<MontlyTask> MontlyTasks { get; set; }

        public virtual DbSet<Ipon> Ipons { get; set; }
    }
}
