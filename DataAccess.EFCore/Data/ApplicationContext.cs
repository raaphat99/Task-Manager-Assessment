using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.EFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>()
            .HasIndex(t => t.Email)
            .IsUnique();

            // Seeding TeamMembers
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, Name = "Ahmed Raafat", Email = "ahmed1999raafat@gmail.com" },
                new TeamMember { Id = 2, Name = "Essam Hosny", Email = "essam1999hosny@gmail.com" },
                new TeamMember { Id = 3, Name = "Asem Hussien", Email = "asem2005hussien@gmail.com" }
            );

            // Seeding Jobs
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Name = "Software Development",
                    Description = "Developing new software applications.",
                    Status = true,
                    StartDate = new DateOnly(2024, 1, 10),
                    EndDate = new DateOnly(2024, 12, 31),
                    TeamMemberId = 1
                },
                new Job
                {
                    Id = 2,
                    Name = "Project Management",
                    Description = "Managing project timelines and deliverables.",
                    Status = true,
                    StartDate = new DateOnly(2024, 2, 1),
                    EndDate = new DateOnly(2024, 8, 31),
                    TeamMemberId = 2
                },
                new Job
                {
                    Id = 3,
                    Name = "Quality Assurance",
                    Description = "Ensuring product quality through testing.",
                    Status = true,
                    StartDate = new DateOnly(2024, 3, 15),
                    EndDate = new DateOnly(2024, 9, 15),
                    TeamMemberId = 1
                },
                new Job
                {
                    Id = 4,
                    Name = "User Experience Design",
                    Description = "Designing user-friendly interfaces.",
                    Status = true,
                    StartDate = new DateOnly(2024, 4, 20),
                    EndDate = new DateOnly(2024, 10, 20),
                    TeamMemberId = 3
                },
                new Job
                {
                    Id = 5,
                    Name = "System Administration",
                    Description = "Maintaining and monitoring IT systems.",
                    Status = false,
                    StartDate = new DateOnly(2024, 5, 5),
                    EndDate = new DateOnly(2024, 11, 5),
                    TeamMemberId = 2
                }
            );
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}





