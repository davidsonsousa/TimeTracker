using TimeTracker.SharedKernel;

namespace TimeTracker.Attend.Core.Model.AttendanceAggregate
{
    public class Branch : Entity<int>
    {
        public string Name { get; private set; }

        public Branch(int id)
        {
            Id = id;
        }

        public Branch()
        {

        }
    }
}
