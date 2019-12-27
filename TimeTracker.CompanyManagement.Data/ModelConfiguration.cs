using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeTracker.CompanyManagement.Core.Models;

namespace TimeTracker.CompanyManagement.Data
{
    public static class ModelConfiguration
    {
        public static void ConfigureBranch(EntityTypeBuilder<Branch> b)
        {
            // Fields
            b.HasKey(model => model.Id);
            b.Property(model => model.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Value objects
            b.OwnsOne(model => model.Address);

            // Relationships
            b.HasOne(model => model.Company);
            b.HasMany(model => model.Holidays);
            b.HasMany(model => model.Employees);
        }

        public static void ConfigureCompany(EntityTypeBuilder<Company> b)
        {
            // Fields
            b.HasKey(model => model.Id);
            b.Property(model => model.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Relationships
            b.HasMany(model => model.Branches);
            b.HasMany(model => model.Projects);
        }

        public static void ConfigureHoliday(EntityTypeBuilder<Holiday> b)
        {
            // Fields
            b.HasKey(model => model.Id);
            b.Property(model => model.Name)
                .HasMaxLength(50)
                .IsRequired();
            b.Property(model => model.Date)
                .IsRequired();
        }

        public static void ConfigureProject(EntityTypeBuilder<Project> b)
        {
            // Fields
            b.HasKey(model => model.Id);
            b.Property(model => model.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Relationships
            b.HasOne(model => model.Company)
                .WithMany(model => model.Projects)
                .HasForeignKey(model => model.CompanyId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

        public static void ConfigureTeam(EntityTypeBuilder<Team> b)
        {
            // Fields
            b.HasKey(model => model.Id);
            b.Property(model => model.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Relationships
            b.HasMany(model => model.TeamMembers);
        }

        // Many to many

        public static void ConfigureBranchTeam(EntityTypeBuilder<BranchTeam> b)
        {
            b.HasKey(model => new { model.BranchId, model.TeamId });
        }

        public static void ConfigureTeamProject(EntityTypeBuilder<TeamProject> b)
        {
            b.HasKey(model => new { model.TeamId, model.ProjectId });
        }
    }
}
