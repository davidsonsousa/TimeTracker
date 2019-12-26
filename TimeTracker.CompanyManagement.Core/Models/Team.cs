using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Branch> Branches { get; set; }
        public List<Project> Projects { get; set; }
        public List<User> TeamMembers { get; set; }

        public Team()
        {
            Branches = new List<Branch>();
            Projects = new List<Project>();
            TeamMembers = new List<User>();
        }
    }
}
