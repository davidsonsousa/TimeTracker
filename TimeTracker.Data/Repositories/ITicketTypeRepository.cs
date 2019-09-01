using System.Collections.Generic;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        IEnumerable<TicketType> GetTicketTypesForBranch(Branch branch);
    }
}
