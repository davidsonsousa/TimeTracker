using System.Collections.Generic;

namespace TimeTracker.Data.Entities
{
    public class Project : BaseModel
    {
        public virtual Company Company { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
