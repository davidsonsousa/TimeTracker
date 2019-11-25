using System;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Model
{
    public class Holiday : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
