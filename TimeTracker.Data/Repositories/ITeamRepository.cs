using System.Collections.Generic;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTeamsForBranch(Branch branch);
    }
}
