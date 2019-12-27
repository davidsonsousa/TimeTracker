using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
