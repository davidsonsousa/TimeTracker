using System.Collections.Generic;

namespace TimeTracker.Data.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
