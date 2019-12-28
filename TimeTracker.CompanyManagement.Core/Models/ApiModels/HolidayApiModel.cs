using System;

namespace TimeTracker.CompanyManagement.Core.Models.ApiModels
{
    public class HolidayApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int BranchId { get; set; }
    }
}
