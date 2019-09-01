using System.Collections.Generic;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsForCompany(Company company);
        IEnumerable<Project> GetProjectsForTeam(Team team);
    }
}
