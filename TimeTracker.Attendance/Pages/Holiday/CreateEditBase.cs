using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Attendance.Shared;
using TimeTracker.Data.EditModels;
using TimeTracker.Services;

namespace TimeTracker.Attendance.Pages.Holiday
{
    public class CreateEditBase : ComponentBase
    {
        protected HolidayEditModel holidayEditModel = new HolidayEditModel();
        protected Alert messageAlert;

        [Inject]
        public Service Service { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
        }

        protected void AddHoliday()
        {
            var returnValue = Service.SaveHoliday(holidayEditModel);

            messageAlert.Message = returnValue.Message;
            messageAlert.AlertType = returnValue.IsError ? "danger" : "success";
            messageAlert.Show();
        }
    }
}
