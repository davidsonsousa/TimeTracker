using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options)
        {
            //Database.SetInitializer(new TimeTrackerInitializer());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }

        // TODO: Add Attendance, Timesheet and User

        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;

            IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            string currentUsername = "";//HttpContext.Current?.User?.Identity?.Name;

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = saveTime;
                    entry.Property("UserCreated").CurrentValue = currentUsername;
                }

                entry.Property("DateModified").CurrentValue = saveTime;
                entry.Property("UserModified").CurrentValue = currentUsername;
            }

            return base.SaveChanges();
        }
    }
}
