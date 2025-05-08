using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_course_ude.Migrations
{
    /// <inheritdoc />
    public partial class AddPropActiveOnCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Category");
        }
    }
}
