using System;

namespace TimeTracker.Data.Entities
{
    public class Attendance : BaseModel
    {
        #region Relationship

        public virtual Branch Calendar { get; set; }

        #endregion

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
