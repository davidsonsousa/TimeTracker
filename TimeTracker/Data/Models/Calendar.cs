﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.Data.Models
{
    public class Calendar
    {
        #region Relationship

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