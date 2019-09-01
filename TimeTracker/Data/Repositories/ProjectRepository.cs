using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public ProjectRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsForCompany(Company company)
        {
            return TimeTrackerContext.Projects
                                     .Include(p => p.Company)
                                     .Where(q => q.Company.Id == company.Id)
                                     .ToList();
        }

        public IEnumerable<Project> GetProjectsForTeam(Team team)
        {
            return TimeTrackerContext.Projects
                                     .Include(p => p.Teams)
                                     .Where(q => q.Teams.Any(t => t.Id == team.Id))
                                     .ToList();
        }
    }
}
