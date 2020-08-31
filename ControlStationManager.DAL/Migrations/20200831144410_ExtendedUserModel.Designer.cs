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
    [Migration("20200831144410_ExtendedUserModel")]
    partial class ExtendedUserModel
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
                            Id = -1,
                            Name = "Aleksinac 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = -2,
                            Name = "Beograd",
                            UserId = 1
                        },
                        new
                        {
                            Id = -3,
                            Name = "Kragujevac",
                            UserId = 4
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ControlStationId");

                    b.ToTable("StationItems");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ControlStationId = -1,
                            LastCheckDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = -2,
                            ControlStationId = -1,
                            LastCheckDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NextCheckDate = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                            PasswordHash = new byte[] { 203, 32, 64, 132, 54, 164, 195, 109, 32, 217, 3, 33, 222, 140, 215, 165, 141, 11, 6, 81, 150, 124, 95, 149, 232, 203, 245, 252, 155, 155, 17, 19, 112, 207, 16, 229, 229, 209, 95, 243, 141, 128, 188, 23, 64, 162, 76, 58, 249, 223, 22, 224, 86, 73, 125, 238, 238, 36, 10, 19, 28, 146, 93, 151 },
                            PasswordSalt = new byte[] { 134, 197, 13, 99, 150, 93, 208, 52, 18, 24, 166, 157, 151, 10, 98, 84, 198, 212, 188, 91, 199, 17, 162, 143, 67, 23, 102, 51, 28, 207, 100, 112, 62, 84, 70, 11, 123, 210, 59, 178, 102, 14, 225, 18, 173, 227, 44, 183, 142, 192, 160, 89, 202, 195, 83, 81, 64, 216, 19, 131, 83, 178, 130, 5, 41, 64, 123, 92, 6, 115, 97, 136, 123, 23, 86, 227, 13, 0, 249, 217, 93, 223, 27, 55, 242, 178, 84, 190, 136, 79, 34, 171, 57, 224, 105, 126, 230, 122, 186, 68, 186, 121, 56, 7, 136, 131, 168, 123, 25, 122, 19, 42, 221, 242, 121, 11, 160, 154, 191, 59, 99, 1, 162, 254, 238, 89, 228, 87 },
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