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
    [Migration("20230606185313_addedProjectModels")]
    partial class addedProjectModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BugTracker.BOL.OrganizationRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrganizationRoles");
                });

            modelBuilder.Entity("BugTracker.BOL.Organizations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BugTracker.BOL.OrganizationUsers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrgRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrgId");

                    b.HasIndex("OrgRolesId");

                    b.ToTable("OrganizationUsers");
                });

            modelBuilder.Entity("BugTracker.BOL.ProjectRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectRoles");
                });

            modelBuilder.Entity("BugTracker.BOL.Projects", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid>("ProjectRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectRolesId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.OrganizationUsers", b =>
                {
                    b.HasOne("BugTracker.BOL.Organizations", "Organizations")
                        .WithMany("OrganizationUsers")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.OrganizationRoles", "OrganizationRoles")
                        .WithMany("OrganizationUsers")
                        .HasForeignKey("OrgRolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrganizationRoles");

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

                    b.HasOne("BugTracker.BOL.ProjectRoles", "ProjectRoles")
                        .WithMany("ProjectUser")
                        .HasForeignKey("ProjectRolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BugTracker.BOL.OrganizationUsers", "OrganizationUsers")
                        .WithMany("ProjectUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrganizationUsers");

                    b.Navigation("ProjectRoles");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("BugTracker.BOL.OrganizationRoles", b =>
                {
                    b.Navigation("OrganizationUsers");
                });

            modelBuilder.Entity("BugTracker.BOL.Organizations", b =>
                {
                    b.Navigation("OrganizationUsers");
                });

            modelBuilder.Entity("BugTracker.BOL.OrganizationUsers", b =>
                {
                    b.Navigation("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.ProjectRoles", b =>
                {
                    b.Navigation("ProjectUser");
                });

            modelBuilder.Entity("BugTracker.BOL.Projects", b =>
                {
                    b.Navigation("ProjectUser");
                });
#pragma warning restore 612, 618
        }
    }
}
