using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Company Company { get; set; }
        public List<Team> Teams { get; set; }

        public Project()
        {
            Company = new Company();
            Teams = new List<Team>();
        }
    }
}
