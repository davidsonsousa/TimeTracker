using System;

namespace TimeTracker.Data.EditModels
{
    public interface IEditModel
    {
        bool IsNew { get; }

        int Id { get; set; }
        Guid VanityId { get; set; }
    }
}
