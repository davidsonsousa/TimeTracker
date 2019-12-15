using TimeTracker.SharedKernel;

namespace TimeTracker.Attend.Core.Model.AttendanceAggregate
{
    public class User : Entity<int>
    {
        public string FullName { get; private set; }

        public User(int id)
        {
            Id = id;
        }

        public User()
        {

        }
    }
}
