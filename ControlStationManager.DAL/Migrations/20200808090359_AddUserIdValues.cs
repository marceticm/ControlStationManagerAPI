using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStationManager.DAL.Migrations
{
    public partial class AddUserIdValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -3,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -3,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "UserId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -1,
                column: "UserId",
                value: 0);
        }
    }
}
