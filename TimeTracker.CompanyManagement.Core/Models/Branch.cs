using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<User> Employees { get; set; }

        public Branch()
        {

        }
    }
}
