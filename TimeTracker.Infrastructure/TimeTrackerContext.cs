using Microsoft.EntityFrameworkCore;
using TimeTracker.Infrastructure.Models;

namespace TimeTracker.Infrastructure
{
    public class TimeTrackerContext : DbContext
    {
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimesheetDetails> TimesheetDetails { get; set; }

        public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options)
        {

        }
    }
}
