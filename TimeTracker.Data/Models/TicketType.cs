using System.Collections.Generic;

namespace TimeTracker.Data.Models
{
    public class TicketType : BaseModel
    {
        public virtual ICollection<Branch> Branches { get; set; }

        public string Name { get; set; }
    }
}
