using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.SharedKernel;
using TimeTracker.SharedKernel.Enums;

namespace TimeTracker.Timesheet.Core.Model.TimesheetAggregate
{
    public class Timesheet : Entity<Guid>
    {
        public int BranchId { get; private set; }
        public DateTime EventDate { get; private set; }

        private List<TimesheetEvent> _timesheetEvents;

        public IEnumerable<TimesheetEvent> TimesheetEvents
        {
            get
            {
                return _timesheetEvents.AsEnumerable();
            }
            private set
            {
                _timesheetEvents = (List<TimesheetEvent>)value;
            }
        }

        public Timesheet(Guid id, DateTime eventDate, int branchId, IEnumerable<TimesheetEvent> timesheetEvents) : base(id)
        {
            EventDate = eventDate;
            BranchId = branchId;
            TimesheetEvents = timesheetEvents;
        }

        // For EF
        public Timesheet() : base(Guid.NewGuid())
        {

        }

        public TimesheetEvent AddNewTimesheetEvent(TimesheetEvent timesheetEvent)
        {
            if (_timesheetEvents.Any(a => a.Id == timesheetEvent.Id))
            {
                throw new ArgumentException("Cannot add duplicate timesheet event.", nameof(TimesheetEvent));
            }

            timesheetEvent.State = TrackingState.Added;
            _timesheetEvents.Add(timesheetEvent);

            return timesheetEvent;
        }

        public void DeleteTimesheetEvent(TimesheetEvent timesheetEvent)
        {
            var timesheetEventToDelete = _timesheetEvents.Where(q => q.Id == timesheetEvent.Id).FirstOrDefault();
            if (timesheetEventToDelete != null)
            {
                timesheetEventToDelete.State = TrackingState.Deleted;
            }
        }
    }
}
