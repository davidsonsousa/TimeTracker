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
        public IEnumerable<HolidayViewModel> GetHolidaysReadOnly()
        {
            return _unitOfWork.Holidays.GetReadOnly().Select(x => new HolidayViewModel
            {
                Id = x.Id,
                VanityId = x.VanityId,
                Name = x.Name,
                Description = x.Description,
                Date = x.Date
            });
        }

        public IEditModel SetupHolidayEditModel()
        {
            return new HolidayEditModel();
        }

        public IEditModel SetupHolidayEditModel(int id)
        {
            var item = _unitOfWork.Holidays.GetById(id);

            return new HolidayEditModel
            {
                Id = item.Id,
                VanityId = item.VanityId,
                Name = item.Name,
                Description = item.Description,
                Date = item.Date
            };
        }

        public IEditModel SetupHolidayEditModel(Guid id)
        {
            var item = _unitOfWork.Holidays.GetById(id);

            return new HolidayEditModel
            {
                Id = item.Id,
                VanityId = item.VanityId,
                Name = item.Name,
                Description = item.Description,
                Date = item.Date
            };
        }

        public ReturnValue SaveHoliday(IEditModel editModel)
        {
            var returnValue = new ReturnValue
            {
                IsError = false,
                Message = $"Holiday '{((HolidayEditModel)editModel).Name}' saved at {DateTime.Now.ToString("T")}"
            };

            try
            {
                var item = (HolidayEditModel)editModel;
                var holiday = new Holiday
                {
                    Id = item.Id,
                    VanityId = item.VanityId,
                    Name = item.Name,
                    Description = item.Description,
                    Date = item.Date
                };

                _unitOfWork.Holidays.Insert(holiday);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while saving the Holiday";
                returnValue.Exception = ex.Message;
                throw;
            }

            return returnValue;
        }
    }
}
