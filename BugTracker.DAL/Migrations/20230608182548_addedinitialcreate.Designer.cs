﻿// <auto-generated />
using System;
using BugTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BugTracker.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230608182548_addedinitialcreate")]
    partial class addedinitialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BugTracker.BOL.AppUsers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("BugTracker.BOL.AttachmentMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AttachmentMaster");
                });

            modelBuilder.Entity("BugTracker.BOL.Organizations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ContactNo")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BugTracker.BOL.Projects", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BugTracker.BOL.ProjectUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskAttachments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskAttachments");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskComments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskComments");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskHistory");
                });

            modelBuilder.Entity("BugTracker.BOL.Tasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BugTracker.BOL.AppUsers", b =>
                {
                    b.HasOne("BugTracker.BOL.Organizations", "Organizations")
                        .WithMany("AppUsers")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("BugTracker.BOL.Projects", b =>
                {
                    b.HasOne("BugTracker.BOL.Organizations", "Organizations")
                        .WithMany()
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("BugTracker.BOL.ProjectUser", b =>
                {
                    b.HasOne("BugTracker.BOL.Projects", "Projects")
                        .WithMany("ProjectUser")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.AppUsers", "OrganizationUsers")
                        .WithMany("ProjectUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrganizationUsers");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskAttachments", b =>
                {
                    b.HasOne("BugTracker.BOL.AttachmentMaster", "AttachmentMaster")
                        .WithMany("TaskAttachments")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.Tasks", "Tasks")
                        .WithMany("TaskAttachments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AttachmentMaster");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskComments", b =>
                {
                    b.HasOne("BugTracker.BOL.ProjectUser", "ProjectUser")
                        .WithMany("TaskComments")
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.Tasks", "Tasks")
                        .WithMany("TaskComments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProjectUser");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BugTracker.BOL.TaskHistory", b =>
                {
                    b.HasOne("BugTracker.BOL.ProjectUser", "ProjectUser")
                        .WithMany("TaskDetail")
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.Tasks", "Tasks")
                        .WithMany("TaskHistory")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProjectUser");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BugTracker.BOL.Tasks", b =>
                {
                    b.HasOne("BugTracker.BOL.ProjectUser", "ProjectUser")
                        .WithMany("Tasks")
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProjectUser");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("BugTracker.BOL.AppUsers", b =>
                {
                    b.Navigation("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.AttachmentMaster", b =>
                {
                    b.Navigation("TaskAttachments");
                });

            modelBuilder.Entity("BugTracker.BOL.Organizations", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("BugTracker.BOL.Projects", b =>
                {
                    b.Navigation("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.ProjectUser", b =>
                {
                    b.Navigation("TaskComments");

                    b.Navigation("TaskDetail");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BugTracker.BOL.Tasks", b =>
                {
                    b.Navigation("TaskAttachments");

                    b.Navigation("TaskComments");

                    b.Navigation("TaskHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
