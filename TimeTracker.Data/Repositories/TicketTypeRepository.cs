using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public class TicketTypeRepository : Repository<TicketType>, ITicketTypeRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public TicketTypeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TicketType> GetTicketTypesForBranch(Branch branch)
        {
            return TimeTrackerContext.TicketTypes
                                     .Include(tt => tt.Branches)
                                     .Where(q => q.Branches.Any(b => b.Id == branch.Id))
                                     .ToList();
        }
    }
}
