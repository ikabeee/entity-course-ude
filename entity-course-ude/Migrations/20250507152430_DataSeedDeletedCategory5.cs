using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_course_ude.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedDeletedCategory5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Category_Id",
                keyValue: 33);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Category_Id", "Active", "CreatedAt", "Name" },
                values: new object[] { 33, true, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Category 5" });
        }
    }
}
