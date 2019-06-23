using System.Collections.Generic;

namespace TimeTracker.Data.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
    }
}
