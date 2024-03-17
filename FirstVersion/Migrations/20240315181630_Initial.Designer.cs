﻿// <auto-generated />
using System;
using FirstVersion.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FirstVersion.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240315181630_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FirstVersion.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasDefaultValue("None");

                    b.Property<int>("Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("City")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasDefaultValue("None");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastLeased")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Model")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasDefaultValue("None");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DriverId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("FirstVersion.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasDefaultValue("Company name");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B"
                        });
                });

            modelBuilder.Entity("FirstVersion.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasDefaultValue("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasDefaultValue("Surname");

                    b.HasKey("Id");

                    b.HasAlternateKey("Login");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FirstVersion.Models.Driver", b =>
                {
                    b.HasBaseType("FirstVersion.Models.User");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasDefaultValue("None");

                    b.Property<DateTime>("DrivingLicenseReceiptDate")
                        .HasColumnType("timestamp with time zone");

                    b.ToTable("drivers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "123",
                            Password = "AQAAAAIAAYagAAAAEPf6PLZx2wO2MPFHqiG/gmc1pS4Cnncj5qpqEGzYt3kKe91xj7oE0mZu0LDvpqdDeA==",
                            Role = 0,
                            Category = 0,
                            DrivingLicenseReceiptDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Login = "1234",
                            Password = "AQAAAAIAAYagAAAAEDQzbQYz9AZ8L95LL6rYX31SbS9futdJ0a18IPtkSgHS6hCoYD3+ECm/oo5Qs62tNA==",
                            Role = 0,
                            Category = 0,
                            DrivingLicenseReceiptDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Login = "12345",
                            Password = "AQAAAAIAAYagAAAAEFoeOHVeMxhdxrYUPgUYhF1cLnSOKQURhEcM4xVqJ5brrHiP0AhIxUo1ZGqn6V/tsw==",
                            Role = 0,
                            Category = 0,
                            DrivingLicenseReceiptDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FirstVersion.Models.Employee", b =>
                {
                    b.HasBaseType("FirstVersion.Models.User");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.HasIndex("CompanyId");

                    b.ToTable("employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Login = "123456",
                            Password = "AQAAAAIAAYagAAAAEIJLuzKRySN7cATLXDjs8nK+hrpYp1H29WzXxQejpu8rbFIg/T/1vvsPsm6Q+1gdJA==",
                            Role = 1,
                            Balance = 0m,
                            CompanyId = 1
                        },
                        new
                        {
                            Id = 5,
                            Login = "1234567",
                            Password = "AQAAAAIAAYagAAAAELGe18TB7OLsFgS/6Q5H63rBzylmpBgHhwshJfFPDNAJt5y2D5PJ7HbDukVsyxMMbw==",
                            Role = 1,
                            Balance = 0m,
                            CompanyId = 2
                        });
                });

            modelBuilder.Entity("FirstVersion.Models.Car", b =>
                {
                    b.HasOne("FirstVersion.Models.Company", "Company")
                        .WithMany("Cars")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstVersion.Models.Driver", "Driver")
                        .WithMany("Cars")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstVersion.Models.Employee", null)
                        .WithMany("CompletedDeals")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Company");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("FirstVersion.Models.Driver", b =>
                {
                    b.HasOne("FirstVersion.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FirstVersion.Models.Driver", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstVersion.Models.Employee", b =>
                {
                    b.HasOne("FirstVersion.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstVersion.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FirstVersion.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("FirstVersion.Models.Company", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FirstVersion.Models.Driver", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("FirstVersion.Models.Employee", b =>
                {
                    b.Navigation("CompletedDeals");
                });
#pragma warning restore 612, 618
        }
    }
}