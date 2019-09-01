using System.Collections.Generic;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        IEnumerable<Holiday> GetHolidaysForBranch(Branch branch);
    }
}
