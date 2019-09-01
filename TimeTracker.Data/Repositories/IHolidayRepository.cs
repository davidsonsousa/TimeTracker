using System.Collections.Generic;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        IEnumerable<Holiday> GetHolidaysForBranch(Branch branch);
    }
}
