namespace TimeTracker.CompanyManagement.Core.Models.ApiModels
{
    public class BranchApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }
    }
}
