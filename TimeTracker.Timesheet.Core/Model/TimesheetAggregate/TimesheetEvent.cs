using System;
using TimeTracker.SharedKernel;
using TimeTracker.SharedKernel.Enums;

namespace TimeTracker.Timesheet.Core.Model.TimesheetAggregate
{
    public class TimesheetEvent : Entity<Guid>
    {
        public int TimesheetId { get; private set; }
        public int UserId { get; private set; }
        public DateTime EventDate { get; private set; }
        public TimesheetEventType EventType { get; private set; }

        public TimesheetEvent(Guid id) : base(id)
        {

        }

        // For EF
        public TimesheetEvent() : base(Guid.NewGuid())
        {

        }

        public static TimesheetEvent Create(int timesheetId, int userId, DateTime eventDate, TimesheetEventType eventType)
        {
            Guard.ForLessEqualZero(timesheetId, nameof(timesheetId));
            Guard.ForLessEqualZero(userId, nameof(userId));

            var timesheetEvent = new TimesheetEvent(Guid.NewGuid())
            {
                TimesheetId = timesheetId,
                UserId = userId,
                EventDate = eventDate,
                EventType = eventType
            };

            return timesheetEvent;
        }
    }
}