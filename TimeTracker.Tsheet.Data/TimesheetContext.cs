using Microsoft.EntityFrameworkCore;
using TimeTracker.Tsheet.Core.Model.TimesheetAggregate;

namespace TimeTracker.Tsheet.Data
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext()
        {
        }

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimesheetEvent> TimesheetEvents { get; set; }
    }
}
