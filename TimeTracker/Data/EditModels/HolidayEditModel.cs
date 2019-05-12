using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.Data.EditModels
{
    public class HolidayEditModel : BaseEditModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
