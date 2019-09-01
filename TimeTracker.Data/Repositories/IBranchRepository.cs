using System.Collections.Generic;
using TimeTracker.Data.Models;

namespace TimeTracker.Data.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        IEnumerable<Branch> GetBranchesForCompany(Company company);
    }
}
