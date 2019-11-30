using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.SharedKernel;
using TimeTracker.SharedKernel.ValueObjects;

namespace TimeTracker.Attend.Core.Model.AttendAggregate
{
    public class Attendance : Entity<Guid>
    {
        public int BranchId { get; private set; }
        public DateTimeRange DateTimeRange { get; private set; }

        private List<AttendanceEvent> _attendanceEvents;
        public IEnumerable<AttendanceEvent> AttendanceEvent
        {
            get
            {
                return _attendanceEvents.AsEnumerable();
            }
            private set
            {
                _attendanceEvents = (List<AttendanceEvent>)value;
            }
        }

        public Attendance(Guid id, DateTimeRange dateTimeRange, int branchId) : base(id)
        {
            DateTimeRange = dateTimeRange;
            BranchId = branchId;
            _attendanceEvents = new List<AttendanceEvent>();
        }

        // Constructor for EF
        public Attendance() : base(Guid.NewGuid())
        {

        }
    }
}
