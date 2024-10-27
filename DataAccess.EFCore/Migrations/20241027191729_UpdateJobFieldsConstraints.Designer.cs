﻿// <auto-generated />
using System;
using DataAccess.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241027191729_UpdateJobFieldsConstraints")]
    partial class UpdateJobFieldsConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("TeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamMemberId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Developing new software applications.",
                            EndDate = new DateOnly(2024, 12, 31),
                            Name = "Software Development",
                            StartDate = new DateOnly(2024, 1, 10),
                            Status = true,
                            TeamMemberId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Managing project timelines and deliverables.",
                            EndDate = new DateOnly(2024, 8, 31),
                            Name = "Project Management",
                            StartDate = new DateOnly(2024, 2, 1),
                            Status = true,
                            TeamMemberId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ensuring product quality through testing.",
                            EndDate = new DateOnly(2024, 9, 15),
                            Name = "Quality Assurance",
                            StartDate = new DateOnly(2024, 3, 15),
                            Status = true,
                            TeamMemberId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Designing user-friendly interfaces.",
                            EndDate = new DateOnly(2024, 10, 20),
                            Name = "User Experience Design",
                            StartDate = new DateOnly(2024, 4, 20),
                            Status = true,
                            TeamMemberId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Maintaining and monitoring IT systems.",
                            EndDate = new DateOnly(2024, 11, 5),
                            Name = "System Administration",
                            StartDate = new DateOnly(2024, 5, 5),
                            Status = false,
                            TeamMemberId = 2
                        });
                });

            modelBuilder.Entity("Domain.Models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ahmed1999raafat@gmail.com",
                            Name = "Ahmed Raafat"
                        },
                        new
                        {
                            Id = 2,
                            Email = "essam1999hosny@gmail.com",
                            Name = "Essam Hosny"
                        },
                        new
                        {
                            Id = 3,
                            Email = "asem2005hussien@gmail.com",
                            Name = "Asem Hussien"
                        });
                });

            modelBuilder.Entity("Domain.Models.Job", b =>
                {
                    b.HasOne("Domain.Models.TeamMember", "TeamMember")
                        .WithMany("Jobs")
                        .HasForeignKey("TeamMemberId");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("Domain.Models.TeamMember", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
