using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Data.ViewModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Components.Pages.Calendar
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
