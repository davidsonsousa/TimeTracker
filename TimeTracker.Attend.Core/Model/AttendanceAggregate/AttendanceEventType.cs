namespace TimeTracker.Attend.Core.Model.AttendanceAggregate
{
    public class AttendanceEventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
    }
}
