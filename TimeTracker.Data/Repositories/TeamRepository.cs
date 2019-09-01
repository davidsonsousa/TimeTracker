using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public TeamRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Team> GetTeamsForBranch(Branch branch)
        {
            return TimeTrackerContext.Teams
                                     .Include(t => t.Branch)
                                     .Where(q => q.Branch.Id == branch.Id)
                                     .ToList();
        }
    }
}
