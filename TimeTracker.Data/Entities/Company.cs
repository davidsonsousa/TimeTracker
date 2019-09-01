using System.Collections.Generic;

namespace TimeTracker.Data.Entities
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
