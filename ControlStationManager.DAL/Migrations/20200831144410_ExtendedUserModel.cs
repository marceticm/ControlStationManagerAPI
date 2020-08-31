using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlStationManager.DAL.Migrations
{
    public partial class ExtendedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "EmailAddress", "FirstName", "JobTitle", "LastName", "PasswordHash", "PasswordSalt", "PhotoUrl", "Username" },
                values: new object[] { 1, new DateTime(1992, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcetic18@hotmail.com", "Dusan", "engineer", "Glisic", new byte[] { 203, 32, 64, 132, 54, 164, 195, 109, 32, 217, 3, 33, 222, 140, 215, 165, 141, 11, 6, 81, 150, 124, 95, 149, 232, 203, 245, 252, 155, 155, 17, 19, 112, 207, 16, 229, 229, 209, 95, 243, 141, 128, 188, 23, 64, 162, 76, 58, 249, 223, 22, 224, 86, 73, 125, 238, 238, 36, 10, 19, 28, 146, 93, 151 }, new byte[] { 134, 197, 13, 99, 150, 93, 208, 52, 18, 24, 166, 157, 151, 10, 98, 84, 198, 212, 188, 91, 199, 17, 162, 143, 67, 23, 102, 51, 28, 207, 100, 112, 62, 84, 70, 11, 123, 210, 59, 178, 102, 14, 225, 18, 173, 227, 44, 183, 142, 192, 160, 89, 202, 195, 83, 81, 64, 216, 19, 131, 83, 178, 130, 5, 41, 64, 123, 92, 6, 115, 97, 136, 123, 23, 86, 227, 13, 0, 249, 217, 93, 223, 27, 55, 242, 178, 84, 190, 136, 79, 34, 171, 57, 224, 105, 126, 230, 122, 186, 68, 186, 121, 56, 7, 136, 131, 168, 123, 25, 122, 19, 42, 221, 242, 121, 11, 160, 154, 191, 59, 99, 1, 162, 254, 238, 89, 228, 87 }, "https://randomuser.me/api/portraits/men/72.jpg", "Dusan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Users");
        }
    }
}
