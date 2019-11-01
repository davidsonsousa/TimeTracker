using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Infrastructure
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options)
        {

        }
    }
}
