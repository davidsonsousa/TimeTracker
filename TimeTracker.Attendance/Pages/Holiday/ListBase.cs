using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Data.ViewModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Pages.Holiday
{
    public class ListBase : ComponentBase
    {
        protected IEnumerable<HolidayViewModel> holidays = new List<HolidayViewModel>();

        [Inject]
        protected Service Service { get; set; }

        protected override Task OnInitAsync()
        {
            RefreshList();

            return base.OnInitAsync();
        }

        protected void RefreshList()
        {
            holidays = Service.GetHolidaysReadOnly();
        }
    }
}
