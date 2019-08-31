using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public class TeamsRepository : Repository<Team>, ITeamRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public TeamsRepository(DbContext context) : base(context)
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
