using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TimeTracker.Attendance.Shared;
using TimeTracker.Data.EditModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Pages.Calendar
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
