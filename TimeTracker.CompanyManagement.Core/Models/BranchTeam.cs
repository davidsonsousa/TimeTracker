namespace TimeTracker.CompanyManagement.Core.Models
{
    public class BranchTeam
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}