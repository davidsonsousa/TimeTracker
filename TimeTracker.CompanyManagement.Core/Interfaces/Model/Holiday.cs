using System;

namespace TimeTracker.CompanyManagement.Core.Interfaces.Model
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
