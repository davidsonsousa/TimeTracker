using System;

namespace TimeTracker.Data.ViewModels
{
    public class HolidayViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
