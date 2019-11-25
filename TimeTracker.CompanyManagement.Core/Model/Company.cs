using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Model
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Branch> Branches { get; set; }
        public List<Project> Projects { get; set; }

        public Company()
        {
            Branches = new List<Branch>();
            Projects = new List<Project>();
        }
    }
}
