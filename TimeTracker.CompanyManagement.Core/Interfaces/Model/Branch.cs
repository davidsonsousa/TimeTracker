using System.Collections.Generic;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.CompanyManagement.Core.Interfaces.Model
{
    public class Branch
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
