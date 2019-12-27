using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<TeamProject> TeamProjects { get; set; }
    }
}
