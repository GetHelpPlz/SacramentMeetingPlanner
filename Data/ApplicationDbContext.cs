using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Hymn> Hymns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure owned types for Meeting
            modelBuilder.Entity<Meeting>(meeting =>
            {
                meeting.OwnsMany(m => m.Hymns, a =>
                {
                    a.WithOwner().HasForeignKey("MeetingId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });

                meeting.OwnsMany(m => m.Speakers, a =>
                {
                    a.WithOwner().HasForeignKey("MeetingId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });
            });
        }
    }
}
