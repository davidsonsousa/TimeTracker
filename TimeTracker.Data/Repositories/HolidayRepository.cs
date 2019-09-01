using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public HolidayRepository(TimeTrackerContext context) : base(context)
        {

        }

        public IEnumerable<Holiday> GetHolidaysForBranch(Branch branch)
        {
            return TimeTrackerContext.Holidays
                                     .Include(h => h.Branch)
                                     .Where(q => q.Branch.Id == branch.Id)
                                     .ToList();
        }
    }
}
