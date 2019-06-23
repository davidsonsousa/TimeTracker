using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.EditModels;
using TimeTracker.Data.Models;
using TimeTracker.Data.ViewModels;

namespace TimeTracker.Services
{
    public sealed partial class Service
    {
        public IEnumerable<CalendarViewModel> GetCalendarsReadOnly()
        {
            return _unitOfWork.Calendars.GetReadOnly().Select(x => new CalendarViewModel
            {
                Id = x.Id,
                VanityId = x.VanityId,
                Name = x.Name,
                HomeOfficeCapacity = x.HomeOfficeCapacity,
                SickDaysCapacity = x.SickDaysCapacity,
                VacationCapacity = x.VacationCapacity
            });
        }

        public IEditModel SetupCalendarEditModel()
        {
            return new CalendarEditModel();
        }

        public IEditModel SetupCalendarEditModel(int id)
        {
            Calendar item = _unitOfWork.Calendars.GetById(id);

            return new CalendarEditModel
            {
                Id = item.Id,
                VanityId = item.VanityId,
                Name = item.Name,
                Description = item.Description,
                HomeOfficeCapacity = item.HomeOfficeCapacity,
                SickDaysCapacity = item.SickDaysCapacity,
                VacationCapacity = item.VacationCapacity
            };
        }

        public IEditModel SetupCalendarEditModel(Guid id)
        {
            Calendar item = _unitOfWork.Calendars.GetById(id);

            return new CalendarEditModel
            {
                Id = item.Id,
                VanityId = item.VanityId,
                Name = item.Name,
                Description = item.Description,
                HomeOfficeCapacity = item.HomeOfficeCapacity,
                SickDaysCapacity = item.SickDaysCapacity,
                VacationCapacity = item.VacationCapacity
            };
        }

        public ReturnValue SaveCalendar(IEditModel editModel)
        {
            var returnValue = new ReturnValue
            {
                IsError = false,
                Message = $"Calendar '{((CalendarEditModel)editModel).Name}' saved at {DateTime.Now.ToString("T")}"
            };

            try
            {
                var item = (CalendarEditModel)editModel;
                var calendar = new Calendar
                {
                    Id = item.Id,
                    VanityId = item.VanityId,
                    Name = item.Name,
                    Description = item.Description,
                    HomeOfficeCapacity = item.HomeOfficeCapacity,
                    SickDaysCapacity = item.SickDaysCapacity,
                    VacationCapacity = item.VacationCapacity
                };

                _unitOfWork.Calendars.Insert(calendar);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while saving the Calendar";
                returnValue.Exception = ex.Message;
                throw;
            }

            return returnValue;
        }
    }
}
