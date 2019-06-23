using System;
using TimeTracker.Enums;

namespace TimeTracker.Data.Models
{
    public class Ticket : BaseModel
    {
        #region Relationship

        public virtual Calendar Calendar { get; set; }

        #endregion

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        // TODO: Enum is a bad decision here. Make it more flexible in the future
        public TicketType TicketType { get; set; }
    }
}
