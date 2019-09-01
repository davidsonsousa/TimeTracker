using System;

namespace TimeTracker.Data.ViewModels
{
    public interface IViewModel
    {
        int Id { get; set; }

        Guid VanityId { get; set; }
    }
}