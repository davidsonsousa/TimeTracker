using System;
using TimeTracker.SharedKernel;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.Attend.Core.Model.AttendAggregate
{
    public class AttendanceEvent : Entity<Guid>
    {
        public int AttendanceId { get; private set; }
        public int UserId { get; private set; }
        public int EventTypeId { get; private set; }
        public DateTimeRange DateTimeRange { get; private set; }

        public AttendanceEvent(Guid id) : base(id)
        {

        }

        // For EF
        public AttendanceEvent() : base(Guid.NewGuid())
        {

        }

        public static AttendanceEvent Create(int attendanceId, int userId, int eventTypeId, DateTimeRange dateTimeRange)
        {
            Guard.ForLessEqualZero(attendanceId, nameof(attendanceId));
            Guard.ForLessEqualZero(userId, nameof(userId));
            Guard.ForLessEqualZero(eventTypeId, nameof(eventTypeId));

            var attendanceEvent = new AttendanceEvent(Guid.NewGuid())
            {
                AttendanceId = attendanceId,
                UserId = userId,
                EventTypeId = eventTypeId,
                DateTimeRange = dateTimeRange
            };

            return attendanceEvent;
        }
    }
}