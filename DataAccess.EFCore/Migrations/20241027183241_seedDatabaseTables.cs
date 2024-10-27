using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class seedDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "ahmed1999raafat@gmail.com", "Ahmed Raafat" },
                    { 2, "essam1999hosny@gmail.com", "Essam Hosny" },
                    { 3, "asem2005hussien@gmail.com", "Asem Hussien" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "Status", "TeamMemberId" },
                values: new object[,]
                {
                    { 1, "Developing new software applications.", new DateOnly(2024, 12, 31), "Software Development", new DateOnly(2024, 1, 10), true, 1 },
                    { 2, "Managing project timelines and deliverables.", new DateOnly(2024, 8, 31), "Project Management", new DateOnly(2024, 2, 1), true, 2 },
                    { 3, "Ensuring product quality through testing.", new DateOnly(2024, 9, 15), "Quality Assurance", new DateOnly(2024, 3, 15), true, 1 },
                    { 4, "Designing user-friendly interfaces.", new DateOnly(2024, 10, 20), "User Experience Design", new DateOnly(2024, 4, 20), true, 3 },
                    { 5, "Maintaining and monitoring IT systems.", new DateOnly(2024, 11, 5), "System Administration", new DateOnly(2024, 5, 5), false, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
