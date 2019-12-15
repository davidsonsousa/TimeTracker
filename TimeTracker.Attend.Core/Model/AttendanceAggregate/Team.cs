using TimeTracker.SharedKernel;

namespace TimeTracker.Attend.Core.Model.AttendanceAggregate
{
    public class Team : Entity<int>
    {
        public string Name { get; private set; }

        public Team(int id)
        {
            Id = id;
        }

        public Team()
        {

        }
    }
}
