using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_course_ude.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Category");
        }
    }
}
