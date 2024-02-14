using GH_Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace GH_Project1.Contexts
{
    public class ActivityManagementDbContext:DbContext
    {
        public ActivityManagementDbContext(DbContextOptions<ActivityManagementDbContext> options) : base(options)
        {
            
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityParticipants> ActivityParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ActivityMDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
