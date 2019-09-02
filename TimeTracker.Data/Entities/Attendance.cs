using System;

namespace TimeTracker.Data.Entities
{
    public class Attendance : BaseModel
    {
        public virtual Branch Calendar { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
