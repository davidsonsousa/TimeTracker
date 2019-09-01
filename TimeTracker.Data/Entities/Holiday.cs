using System;

namespace TimeTracker.Data.Entities
{
    public class Holiday : BaseModel
    {
        public virtual Branch Branch { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
