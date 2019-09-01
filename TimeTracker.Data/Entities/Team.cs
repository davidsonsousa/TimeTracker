namespace TimeTracker.Data.Entities
{
    public class Team : BaseModel
    {
        public virtual Branch Branch { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
