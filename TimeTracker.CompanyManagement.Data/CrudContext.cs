using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTracker.CompanyManagement.Core.Model;

namespace TimeTracker.CompanyManagement.Data
{
    public class CrudContext : IdentityDbContext<User>
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Branch>(ModelConfiguration.ConfigureBranch);
            builder.Entity<Company>(ModelConfiguration.ConfigureCompany);
            builder.Entity<Holiday>(ModelConfiguration.ConfigureHoliday);
            builder.Entity<Project>(ModelConfiguration.ConfigureProject);
            builder.Entity<Team>(ModelConfiguration.ConfigureTeam);

            base.OnModelCreating(builder);
        }
    }
}
