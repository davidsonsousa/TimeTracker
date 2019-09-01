namespace TimeTracker.Data.Models
{
    public class Team : BaseModel
    {
        public virtual Branch Branch { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
