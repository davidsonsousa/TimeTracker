using System.Collections.Generic;

namespace TimeTracker.Data.Models
{
    public class Calendar : BaseModel
    {
        #region Relationship

        public virtual Company Company { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }

        #endregion

        public string Name { get; set; }
        public string Description { get; set; }
        public string VacationCapacity { get; set; }
        public string HomeOfficeCapacity { get; set; }
        public string SickDaysCapacity { get; set; }
    }
}
