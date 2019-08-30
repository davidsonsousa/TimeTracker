using System;

namespace TimeTracker.Data.Models
{
    public class Holiday : BaseModel
    {
        public virtual Branch Calendar { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
