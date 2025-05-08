using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace entity_course_ude.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedOnCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Category_Id", "Active", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 33, true, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category 5" },
                    { 34, true, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Category_Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Category_Id",
                keyValue: 34);
        }
    }
}
