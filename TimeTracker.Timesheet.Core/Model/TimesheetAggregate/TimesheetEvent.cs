using System;
using TimeTracker.SharedKernel;

namespace TimeTracker.Timesheet.Core.Model.TimesheetAggregate
{
    public class TimesheetEvent : Entity<Guid>
    {
        public int TimesheetId { get; private set; }
        public int UserId { get; private set; }
        public DateTime EventDate { get; private set; }

        public TimesheetEvent(Guid id) : base(id)
        {

        }

        // For EF
        public TimesheetEvent() : base(Guid.NewGuid())
        {

        }

        public static TimesheetEvent Create(int timesheetId, int userId, DateTime eventDate)
        {
            Guard.ForLessEqualZero(timesheetId, nameof(timesheetId));
            Guard.ForLessEqualZero(userId, nameof(userId));

            var timesheetEvent = new TimesheetEvent(Guid.NewGuid())
            {
                TimesheetId = timesheetId,
                UserId = userId,
                EventDate = eventDate
            };

            return timesheetEvent;
        }
    }
}