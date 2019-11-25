using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.SharedKernel;

namespace TimeTracker.Timesheet.Core.Model.TimesheetAggregate
{
    public class Timesheet : Entity<Guid>
    {
        public int BranchId { get; private set; }
        public DateTime EventDate { get; private set; }

        private List<TimesheetEvent> timeSheetEvents;

        public IEnumerable<TimesheetEvent> TimesheetEvents
        {
            get
            {
                return timeSheetEvents.AsEnumerable();
            }
            private set
            {
                timeSheetEvents = (List<TimesheetEvent>)value;
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
    }
}
