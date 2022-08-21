﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TT.Diary.DataAccessLogic;

#nullable disable

namespace TT.Diary.DataAccessLogic.Migrations
{
    [DbContext(typeof(DiaryDBContext))]
    [Migration("20220526004859_PM")]
    partial class PM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletionDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<uint>("DaysAmount")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Every")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Months")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Repeat")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ScheduledCompletionDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduledStartDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weekdays")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TimeManagement.Tracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HabitId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Progress")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ScheduledDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ToDoId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("HabitId");

                    b.HasIndex("ToDoId");

                    b.ToTable("Trackers");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduleDateUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ToDoList");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Wish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sub")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TimeManagement.Tracker", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Appointment", "Owner")
                        .WithMany("Trackers")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Habit", null)
                        .WithMany("Trackers")
                        .HasForeignKey("HabitId");

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.ToDo", null)
                        .WithMany("Trackers")
                        .HasForeignKey("ToDoId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Appointment", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Category")
                        .WithMany("Appointments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Category");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Category", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Parent")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentId");

                    b.HasOne("TT.Diary.DataAccessLogic.Model.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Habit", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Category")
                        .WithMany("Habits")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", "Schedule")
                        .WithOne("Owner")
                        .HasForeignKey("TT.Diary.DataAccessLogic.Model.TypeList.Habit", "ScheduleId");

                    b.Navigation("Category");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Note", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Category")
                        .WithMany("Notes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.ToDo", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Category")
                        .WithMany("ToDoList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Category");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Wish", b =>
                {
                    b.HasOne("TT.Diary.DataAccessLogic.Model.TypeList.Category", "Category")
                        .WithMany("WishList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Category");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TimeManagement.ScheduleSettings", b =>
                {
                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Appointment", b =>
                {
                    b.Navigation("Trackers");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Category", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Habits");

                    b.Navigation("Notes");

                    b.Navigation("Subcategories");

                    b.Navigation("ToDoList");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.Habit", b =>
                {
                    b.Navigation("Trackers");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.TypeList.ToDo", b =>
                {
                    b.Navigation("Trackers");
                });

            modelBuilder.Entity("TT.Diary.DataAccessLogic.Model.User", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
