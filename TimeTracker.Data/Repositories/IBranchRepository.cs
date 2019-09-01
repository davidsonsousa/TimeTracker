using System.Collections.Generic;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        IEnumerable<Branch> GetBranchesForCompany(Company company);
    }
}
