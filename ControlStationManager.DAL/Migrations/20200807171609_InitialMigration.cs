using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStationManager.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastCheckDate = table.Column<DateTime>(nullable: false),
                    NextCheckDate = table.Column<DateTime>(nullable: false),
                    ControlStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationItems_ControlStations_ControlStationId",
                        column: x => x.ControlStationId,
                        principalTable: "ControlStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ControlStations",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { -1, "Aleksinac 1", null });

            migrationBuilder.InsertData(
                table: "ControlStations",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { -2, "Beograd", null });

            migrationBuilder.InsertData(
                table: "ControlStations",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { -3, "Kragujevac", null });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate" },
                values: new object[] { -1, -1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate" },
                values: new object[] { -2, -1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_StationItems_ControlStationId",
                table: "StationItems",
                column: "ControlStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ControlStations");
        }
    }
}
