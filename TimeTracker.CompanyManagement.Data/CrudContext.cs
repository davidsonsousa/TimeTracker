using Microsoft.EntityFrameworkCore;
using TimeTracker.CompanyManagement.Core.Model;

namespace TimeTracker.CompanyManagement.Data
{
    public class CrudContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public CrudContext()
        {

        }
    }
}
