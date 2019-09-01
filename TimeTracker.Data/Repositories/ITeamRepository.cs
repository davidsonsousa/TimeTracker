using System.Collections.Generic;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTeamsForBranch(Branch branch);
    }
}
