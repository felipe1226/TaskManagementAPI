﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementAPI.Data;

#nullable disable

namespace TaskManagementAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231105001032_add_user_and_workTaskStatus_data_fix")]
    partial class add_user_and_workTaskStatus_data_fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagementAPI.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<Guid>("UserProfile")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserProfile");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Waypoint", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("Location")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<Guid>("WorkTask")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Location");

                    b.HasIndex("WorkTask");

                    b.ToTable("Waypoint");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.WorkTask", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Observation")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("User");

                    b.ToTable("WorkTask");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.WorkTaskStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Observation")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("State")
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<Guid>("Status")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkTask")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkTask");

                    b.ToTable("WorkTaskStatus");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.User", b =>
                {
                    b.HasOne("TaskManagementAPI.Models.UserProfile", "UserProfileNavigation")
                        .WithMany("Users")
                        .HasForeignKey("UserProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_UserProfile");

                    b.Navigation("UserProfileNavigation");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Waypoint", b =>
                {
                    b.HasOne("TaskManagementAPI.Models.Location", "LocationNavigation")
                        .WithMany("Waypoints")
                        .HasForeignKey("Location")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Waypoint_Location");

                    b.HasOne("TaskManagementAPI.Models.WorkTask", "WorkTaskNavigation")
                        .WithMany("Waypoints")
                        .HasForeignKey("WorkTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Waypoint_WorkTask");

                    b.Navigation("LocationNavigation");

                    b.Navigation("WorkTaskNavigation");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.WorkTask", b =>
                {
                    b.HasOne("TaskManagementAPI.Models.Category", "CategoryNavigation")
                        .WithMany("WorkTasks")
                        .HasForeignKey("Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WorkTask_Category");

                    b.HasOne("TaskManagementAPI.Models.User", "UserNavigation")
                        .WithMany("WorkTasks")
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WorkTask_User");

                    b.Navigation("CategoryNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.WorkTaskStatus", b =>
                {
                    b.HasOne("TaskManagementAPI.Models.Status", "StatusNavigation")
                        .WithMany("WorkTaskStatuses")
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WorkTaskStatus_Status");

                    b.HasOne("TaskManagementAPI.Models.User", null)
                        .WithMany("WorkTaskStatuses")
                        .HasForeignKey("UserId");

                    b.HasOne("TaskManagementAPI.Models.WorkTask", "WorkTaskNavigation")
                        .WithMany("WorkTaskStatuses")
                        .HasForeignKey("WorkTask")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WorkTaskStatus_WorkTask");

                    b.Navigation("StatusNavigation");

                    b.Navigation("WorkTaskNavigation");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Category", b =>
                {
                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Location", b =>
                {
                    b.Navigation("Waypoints");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.Status", b =>
                {
                    b.Navigation("WorkTaskStatuses");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.User", b =>
                {
                    b.Navigation("WorkTaskStatuses");

                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.UserProfile", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TaskManagementAPI.Models.WorkTask", b =>
                {
                    b.Navigation("Waypoints");

                    b.Navigation("WorkTaskStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
