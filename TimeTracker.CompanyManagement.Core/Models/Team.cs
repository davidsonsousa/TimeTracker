using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BranchTeam> BranchTeams { get; set; }
        public ICollection<TeamProject> TeamProjects { get; set; }
        public ICollection<User> TeamMembers { get; set; }
    }
}
