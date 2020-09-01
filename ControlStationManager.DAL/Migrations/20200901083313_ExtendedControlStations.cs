using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStationManager.DAL.Migrations
{
    public partial class ExtendedControlStations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ControlStations",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ControlStations",
                columns: new[] { "Id", "Address", "Name", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, "Bulevar Patrijarha Pavla 9", "Aleksinac 1", "GMRS", 1 },
                    { 2, "Bulevar Oslobodjenja 156", "Beograd", "GMRS", 1 },
                    { 3, "Gandijeva 90", "Kragujevac 2", "MRS", 1 },
                    { 4, "Bulevar Nikole Tesle BB", "Nis 1", "GMRS", 1 },
                    { 5, "Kisacka 66", "Novi Sad 1", "GMRS", 1 },
                    { 6, "Paunova 19", "Beograd 2", "GMRS", 1 },
                    { 7, "Bulevar Zorana Djindjica 10", "Beograd 3", "MRS", 1 },
                    { 8, "Vrsacka 98", "Novi Sad 2", "GMRS", 1 },
                    { 9, "Despota Stefana BB", "Sabac 1", "GMRS", 1 },
                    { 10, "27. marta 45", "Kragujevac 1", "GMRS", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 169, 183, 174, 85, 182, 121, 170, 45, 139, 3, 168, 181, 195, 26, 219, 10, 143, 67, 148, 126, 116, 142, 214, 171, 188, 87, 198, 174, 214, 44, 49, 150, 181, 0, 133, 177, 122, 143, 204, 247, 44, 95, 122, 185, 229, 245, 39, 143, 198, 110, 189, 139, 113, 162, 2, 92, 112, 156, 23, 213, 174, 58, 233 }, new byte[] { 93, 76, 249, 62, 243, 227, 134, 154, 227, 119, 146, 70, 104, 109, 255, 136, 237, 201, 66, 1, 45, 91, 142, 203, 58, 108, 94, 14, 126, 183, 149, 203, 234, 116, 81, 47, 100, 143, 250, 57, 230, 195, 138, 144, 127, 169, 189, 172, 240, 61, 25, 32, 214, 24, 161, 137, 201, 110, 246, 44, 116, 227, 115, 201, 62, 76, 134, 162, 184, 35, 73, 76, 249, 26, 243, 251, 120, 119, 33, 122, 240, 241, 132, 3, 21, 72, 57, 240, 69, 109, 199, 189, 142, 113, 36, 37, 76, 253, 145, 37, 125, 124, 179, 84, 94, 187, 124, 198, 250, 57, 37, 126, 140, 49, 112, 182, 242, 39, 208, 25, 231, 35, 139, 93, 177, 223, 191, 235 } });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -2, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -1, 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "StationItems",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ControlStations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "ControlStations");

            migrationBuilder.InsertData(
                table: "ControlStations",
                columns: new[] { "Id", "Name", "Type", "UserId" },
                values: new object[,]
                {
                    { -1, "Aleksinac 1", null, 1 },
                    { -2, "Beograd", null, 1 },
                    { -3, "Kragujevac", null, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 32, 64, 132, 54, 164, 195, 109, 32, 217, 3, 33, 222, 140, 215, 165, 141, 11, 6, 81, 150, 124, 95, 149, 232, 203, 245, 252, 155, 155, 17, 19, 112, 207, 16, 229, 229, 209, 95, 243, 141, 128, 188, 23, 64, 162, 76, 58, 249, 223, 22, 224, 86, 73, 125, 238, 238, 36, 10, 19, 28, 146, 93, 151 }, new byte[] { 134, 197, 13, 99, 150, 93, 208, 52, 18, 24, 166, 157, 151, 10, 98, 84, 198, 212, 188, 91, 199, 17, 162, 143, 67, 23, 102, 51, 28, 207, 100, 112, 62, 84, 70, 11, 123, 210, 59, 178, 102, 14, 225, 18, 173, 227, 44, 183, 142, 192, 160, 89, 202, 195, 83, 81, 64, 216, 19, 131, 83, 178, 130, 5, 41, 64, 123, 92, 6, 115, 97, 136, 123, 23, 86, 227, 13, 0, 249, 217, 93, 223, 27, 55, 242, 178, 84, 190, 136, 79, 34, 171, 57, 224, 105, 126, 230, 122, 186, 68, 186, 121, 56, 7, 136, 131, 168, 123, 25, 122, 19, 42, 221, 242, 121, 11, 160, 154, 191, 59, 99, 1, 162, 254, 238, 89, 228, 87 } });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -2, -1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "StationItems",
                columns: new[] { "Id", "ControlStationId", "LastCheckDate", "NextCheckDate", "UserId" },
                values: new object[] { -1, -1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }
    }
}
