﻿// <auto-generated />
using System;
using ControlStationManager.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlStationManager.DAL.Migrations
{
    [DbContext(typeof(ControlStationContext))]
    [Migration("20200907135129_ExtendStationItem")]
    partial class ExtendStationItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlStationManager.DAL.Entities.ControlStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ControlStations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bulevar Patrijarha Pavla 9",
                            Name = "Aleksinac 1",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bulevar Oslobodjenja 156",
                            Name = "Beograd",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Gandijeva 90",
                            Name = "Kragujevac 2",
                            Type = "MRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Address = "Bulevar Nikole Tesle BB",
                            Name = "Nis 1",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            Address = "Kisacka 66",
                            Name = "Novi Sad 1",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Address = "Paunova 19",
                            Name = "Beograd 2",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Address = "Bulevar Zorana Djindjica 10",
                            Name = "Beograd 3",
                            Type = "MRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            Address = "Vrsacka 98",
                            Name = "Novi Sad 2",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            Address = "Despota Stefana BB",
                            Name = "Sabac 1",
                            Type = "GMRS",
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            Address = "27. marta 45",
                            Name = "Kragujevac 1",
                            Type = "GMRS",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ControlStationManager.DAL.Entities.StationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ControlStationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastCheckDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextCheckDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ControlStationId");

                    b.ToTable("StationItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456789",
                            Type = "Fire Extinguisher",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456781",
                            Type = "Fire Extinguisher",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456782",
                            Type = "Filter",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456783",
                            Type = "Heater",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456784",
                            Type = "Fire Extinguisher",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456785",
                            Type = "Valve",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456786",
                            Type = "Fire Extinguisher",
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456787",
                            Type = "Valve",
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123456788",
                            Type = "Heater",
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            ControlStationId = 1,
                            LastCheckDate = new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SerialNumber = "123454782",
                            Type = "Filter",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ControlStationManager.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1992, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "marcetic18@hotmail.com",
                            FirstName = "Dusan",
                            JobTitle = "engineer",
                            LastName = "Glisic",
                            PasswordHash = new byte[] { 152, 4, 175, 172, 10, 217, 218, 250, 31, 187, 251, 2, 6, 144, 94, 72, 247, 99, 6, 208, 152, 152, 179, 77, 181, 23, 254, 216, 129, 53, 42, 6, 31, 211, 166, 254, 186, 213, 169, 191, 172, 106, 86, 171, 195, 18, 93, 172, 0, 202, 253, 246, 102, 118, 120, 18, 253, 61, 160, 88, 26, 119, 169, 59 },
                            PasswordSalt = new byte[] { 231, 51, 127, 134, 13, 233, 31, 196, 113, 92, 39, 98, 2, 134, 80, 13, 56, 64, 157, 61, 205, 213, 205, 119, 191, 185, 224, 130, 237, 16, 218, 150, 132, 115, 62, 165, 181, 179, 70, 51, 157, 214, 249, 97, 228, 107, 156, 2, 46, 59, 95, 246, 212, 137, 106, 24, 120, 192, 29, 67, 207, 205, 154, 169, 196, 204, 254, 236, 225, 214, 30, 116, 160, 247, 224, 74, 11, 189, 201, 3, 91, 133, 177, 1, 218, 35, 224, 74, 252, 225, 67, 160, 92, 94, 5, 130, 13, 129, 212, 194, 204, 91, 185, 199, 154, 186, 84, 166, 155, 83, 7, 15, 235, 178, 181, 46, 57, 150, 149, 201, 241, 209, 34, 105, 140, 46, 250, 51 },
                            PhotoUrl = "https://randomuser.me/api/portraits/men/72.jpg",
                            Username = "Dusan"
                        });
                });

            modelBuilder.Entity("ControlStationManager.DAL.Entities.StationItem", b =>
                {
                    b.HasOne("ControlStationManager.DAL.Entities.ControlStation", "ControlStation")
                        .WithMany("StationItems")
                        .HasForeignKey("ControlStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
