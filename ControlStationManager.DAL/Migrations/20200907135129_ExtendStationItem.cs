using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStationManager.DAL.Migrations
{
    public partial class ExtendStationItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "StationItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "StationItems",
                nullable: true);

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "SerialNumber", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456789", "Fire Extinguisher", 1 },
                    { 2, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456781", "Fire Extinguisher", 1 },
                    { 3, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456782", "Filter", 1 },
                    { 4, 1, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456783", "Heater", 1 },
                    { 5, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456784", "Fire Extinguisher", 1 },
                    { 6, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456785", "Valve", 1 },
                    { 7, 1, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456786", "Fire Extinguisher", 1 },
                    { 8, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456787", "Valve", 1 },
                    { 9, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "123456788", "Heater", 1 },
                    { 10, 1, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "123454782", "Filter", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 4, 175, 172, 10, 217, 218, 250, 31, 187, 251, 2, 6, 144, 94, 72, 247, 99, 6, 208, 152, 152, 179, 77, 181, 23, 254, 216, 129, 53, 42, 6, 31, 211, 166, 254, 186, 213, 169, 191, 172, 106, 86, 171, 195, 18, 93, 172, 0, 202, 253, 246, 102, 118, 120, 18, 253, 61, 160, 88, 26, 119, 169, 59 }, new byte[] { 231, 51, 127, 134, 13, 233, 31, 196, 113, 92, 39, 98, 2, 134, 80, 13, 56, 64, 157, 61, 205, 213, 205, 119, 191, 185, 224, 130, 237, 16, 218, 150, 132, 115, 62, 165, 181, 179, 70, 51, 157, 214, 249, 97, 228, 107, 156, 2, 46, 59, 95, 246, 212, 137, 106, 24, 120, 192, 29, 67, 207, 205, 154, 169, 196, 204, 254, 236, 225, 214, 30, 116, 160, 247, 224, 74, 11, 189, 201, 3, 91, 133, 177, 1, 218, 35, 224, 74, 252, 225, 67, 160, 92, 94, 5, 130, 13, 129, 212, 194, 204, 91, 185, 199, 154, 186, 84, 166, 155, 83, 7, 15, 235, 178, 181, 46, 57, 150, 149, 201, 241, 209, 34, 105, 140, 46, 250, 51 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "StationItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StationItems");

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -1, 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -2, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 169, 183, 174, 85, 182, 121, 170, 45, 139, 3, 168, 181, 195, 26, 219, 10, 143, 67, 148, 126, 116, 142, 214, 171, 188, 87, 198, 174, 214, 44, 49, 150, 181, 0, 133, 177, 122, 143, 204, 247, 44, 95, 122, 185, 229, 245, 39, 143, 198, 110, 189, 139, 113, 162, 2, 92, 112, 156, 23, 213, 174, 58, 233 }, new byte[] { 93, 76, 249, 62, 243, 227, 134, 154, 227, 119, 146, 70, 104, 109, 255, 136, 237, 201, 66, 1, 45, 91, 142, 203, 58, 108, 94, 14, 126, 183, 149, 203, 234, 116, 81, 47, 100, 143, 250, 57, 230, 195, 138, 144, 127, 169, 189, 172, 240, 61, 25, 32, 214, 24, 161, 137, 201, 110, 246, 44, 116, 227, 115, 201, 62, 76, 134, 162, 184, 35, 73, 76, 249, 26, 243, 251, 120, 119, 33, 122, 240, 241, 132, 3, 21, 72, 57, 240, 69, 109, 199, 189, 142, 113, 36, 37, 76, 253, 145, 37, 125, 124, 179, 84, 94, 187, 124, 198, 250, 57, 37, 126, 140, 49, 112, 182, 242, 39, 208, 25, 231, 35, 139, 93, 177, 223, 191, 235 } });
        }
    }
}
