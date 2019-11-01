using System.Collections.Generic;

namespace TimeTracker.Infrastructure.Models
{
    public class Timesheet : BaseModel
    {
        //public virtual int User { get; set; }
        public virtual ICollection<TimesheetDetails> TimesheetDetails { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
