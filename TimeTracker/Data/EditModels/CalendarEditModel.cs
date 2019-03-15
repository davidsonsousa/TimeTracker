﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.EditModels
{
    public class CalendarEditModel : BaseEditModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VacationCapacity { get; set; }
        public string HomeOfficeCapacity { get; set; }
        public string SickDaysCapacity { get; set; }
    }
}