using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Attendance.Components.Shared;
using TimeTracker.Data.EditModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Components.Pages.Calendar
{
    public class CreateEditBase : ComponentBase
    {
        protected CalendarEditModel calendarEditModel = new CalendarEditModel();
        protected Alert messageAlert;

        [Inject]
        public Service Service { get; set; }

        protected override Task OnInitAsync()
        {
            return base.OnInitAsync();
        }

        protected void AddCalendar()
        {
            var returnValue = Service.SaveCalendar(calendarEditModel);

            messageAlert.Message = returnValue.Message;
            messageAlert.AlertType = returnValue.IsError ? "danger" : "success";
            messageAlert.Show();
        }
    }
}
