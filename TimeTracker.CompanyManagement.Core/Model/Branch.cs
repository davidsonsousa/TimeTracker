using System.Collections.Generic;
using TimeTracker.CompanyManagement.Core.Interfaces;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.CompanyManagement.Core.Model
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public Company Company { get; set; }
        public List<Team> Teams { get; set; }
        public List<Holiday> Holidays { get; set; }
        public List<User> Employees { get; set; }

        public Branch()
        {
            Company = new Company();
            Teams = new List<Team>();
            Holidays = new List<Holiday>();
            Employees = new List<User>();
        }
    }
}
