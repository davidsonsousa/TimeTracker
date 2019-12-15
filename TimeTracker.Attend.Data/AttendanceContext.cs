using Microsoft.EntityFrameworkCore;
using TimeTracker.Attend.Core.Model.AttendanceAggregate;

namespace TimeTracker.Attend.Data
{
    public class AttendanceContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceEvent> AttendanceEvents { get; set; }
        public DbSet<AttendanceEventType> AttendanceEventType { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public AttendanceContext()
        {

        }
    }
}
