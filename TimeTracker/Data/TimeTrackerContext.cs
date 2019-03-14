using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.Models;

namespace TimeTracker.Data
{
    public class TimeTrackerContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public override int SaveChanges()
        {
            var saveTime = DateTime.Now;

            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            var currentUsername = "";//HttpContext.Current?.User?.Identity?.Name;

            foreach (var entry in entries)
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
