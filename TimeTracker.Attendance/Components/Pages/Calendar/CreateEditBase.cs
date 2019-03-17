using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.EditModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Components.Pages.Calendar
{
    public class CreateEditBase : ComponentBase
    {
        protected CalendarEditModel calendarEditModel = new CalendarEditModel();

        [Inject]
        public Service Service { get; set; }

        protected void AddCalendar()
        {
            var returnValue = Service.SaveCalendar(calendarEditModel);
        }
    }
}
