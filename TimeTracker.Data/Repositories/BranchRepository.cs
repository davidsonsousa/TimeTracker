using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.Data.Entities;

namespace TimeTracker.Data.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public TimeTrackerContext TimeTrackerContext
        {
            get { return Context as TimeTrackerContext; }
        }

        public BranchRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Branch> GetBranchesForCompany(Company company)
        {
            return TimeTrackerContext.Branches
                                     .Include(b => b.Company)
                                     .Where(q => q.Company.Id == company.Id)
                                     .ToList();
        }
    }
}
