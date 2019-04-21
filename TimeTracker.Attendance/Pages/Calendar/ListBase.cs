using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Data.ViewModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Pages.Calendar
{
    public class ListBase : ComponentBase
    {
        protected IEnumerable<CalendarViewModel> calendars = new List<CalendarViewModel>();

        [Inject]
        public Service Service { get; set; }

        protected override Task OnInitAsync()
        {
            RefreshList();

            return base.OnInitAsync();
        }

        protected void RefreshList()
        {
            calendars = Service.GetCalendarsReadOnly();
        }
    }
}
