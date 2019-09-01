using System.Collections.Generic;

namespace TimeTracker.Data.Models
{
    public class Branch : BaseModel
    {
        public virtual Company Company { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<TicketType> TicketTypes { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string VacationCapacity { get; set; }
        public string HomeOfficeCapacity { get; set; }
        public string SickDaysCapacity { get; set; }
    }
}
