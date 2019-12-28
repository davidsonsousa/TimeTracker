using System;
using TimeTracker.CompanyManagement.Core.Interfaces;

namespace TimeTracker.CompanyManagement.Core.Models
{
    public class Holiday : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int BranchId { get; set; }
    }
}
