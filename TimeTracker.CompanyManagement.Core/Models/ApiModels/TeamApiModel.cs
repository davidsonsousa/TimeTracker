using System.Collections.Generic;

namespace TimeTracker.CompanyManagement.Core.Models.ApiModels
{
    public class TeamApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> Branches { get; set; }
        public IList<int> Projects { get; set; }
        public IList<int> TeamMembers { get; set; }
    }
}
