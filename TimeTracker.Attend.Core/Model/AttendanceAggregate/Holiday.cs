using System;
using TimeTracker.SharedKernel;

namespace TimeTracker.Attend.Core.Model.AttendanceAggregate
{
    public class Holiday : Entity<int>
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public Holiday(int id)
        {
            Id = id;
        }

        public Holiday()
        {

        }
    }
}
