using System;

namespace TimeTracker.Infrastructure.Models
{
    public class TimesheetDetails : BaseModel
    {
        public DateTime EntranceTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}
