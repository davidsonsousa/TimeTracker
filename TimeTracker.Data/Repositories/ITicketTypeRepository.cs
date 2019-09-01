using System.Collections.Generic;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        IEnumerable<TicketType> GetTicketTypesForBranch(Branch branch);
    }
}
