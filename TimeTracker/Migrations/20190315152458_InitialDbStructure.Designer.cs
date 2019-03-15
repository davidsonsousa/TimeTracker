﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTracker.Data;

namespace TimeTracker.Migrations
{
    [DbContext(typeof(TimeTrackerContext))]
    [Migration("20190315152458_InitialDbStructure")]
    partial class InitialDbStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview3.19153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeTracker.Data.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserModified");

                    b.Property<Guid>("VanityId");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("HomeOfficeCapacity");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("SickDaysCapacity");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserModified");

                    b.Property<string>("VacationCapacity");

                    b.Property<Guid>("VanityId");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserModified");

                    b.Property<Guid>("VanityId");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserModified");

                    b.Property<Guid>("VanityId");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TicketType");

                    b.Property<string>("UserCreated");

                    b.Property<string>("UserModified");

                    b.Property<Guid>("VanityId");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Attendance", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.Calendar", "Calendar")
                        .WithMany()
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Holiday", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.Calendar", "Calendar")
                        .WithMany("Holidays")
                        .HasForeignKey("CalendarId");
                });

            modelBuilder.Entity("TimeTracker.Data.Models.Ticket", b =>
                {
                    b.HasOne("TimeTracker.Data.Models.Calendar", "Calendar")
                        .WithMany("Tickets")
                        .HasForeignKey("CalendarId");
                });
#pragma warning restore 612, 618
        }
    }
}
