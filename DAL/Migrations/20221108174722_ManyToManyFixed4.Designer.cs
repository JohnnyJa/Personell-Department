﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(PersonnelDepartmentContext))]
    [Migration("20221108174722_ManyToManyFixed4")]
    partial class ManyToManyFixed4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("DAL.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<int>("WorkingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("DAL.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DAL.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AttachedToDivisionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OccupiedPositionId")
                        .HasColumnType("int");

                    b.Property<string>("SalaryAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttachedToDivisionId");

                    b.HasIndex("OccupiedPositionId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("ProjectId");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int")
                        .HasColumnName("WorkerId");

                    b.HasKey("ProjectId", "WorkerId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ProjectId", "WorkerId"), false);

                    b.HasIndex("WorkerId");

                    b.ToTable("ProjectWorkers", (string)null);
                });

            modelBuilder.Entity("DAL.Worker", b =>
                {
                    b.HasOne("DAL.Division", "AttachedToDivision")
                        .WithMany("AttachedWorkers")
                        .HasForeignKey("AttachedToDivisionId");

                    b.HasOne("DAL.Position", "OccupiedPosition")
                        .WithMany("WorkersOnPosition")
                        .HasForeignKey("OccupiedPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttachedToDivision");

                    b.Navigation("OccupiedPosition");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.HasOne("DAL.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProjectWorker_Projects");

                    b.HasOne("DAL.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProjectWorker_Workers");
                });

            modelBuilder.Entity("DAL.Division", b =>
                {
                    b.Navigation("AttachedWorkers");
                });

            modelBuilder.Entity("DAL.Position", b =>
                {
                    b.Navigation("WorkersOnPosition");
                });
#pragma warning restore 612, 618
        }
    }
}
