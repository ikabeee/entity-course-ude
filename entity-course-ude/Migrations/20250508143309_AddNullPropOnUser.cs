using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_course_ude.Migrations
{
    /// <inheritdoc />
    public partial class AddNullPropOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserDetail_UserDetail_Id",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserDetail_Id",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetail_Id",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserDetail_Id",
                table: "User",
                column: "UserDetail_Id",
                unique: true,
                filter: "[UserDetail_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserDetail_UserDetail_Id",
                table: "User",
                column: "UserDetail_Id",
                principalTable: "UserDetail",
                principalColumn: "UserDetail_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserDetail_UserDetail_Id",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserDetail_Id",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserDetail_Id",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserDetail_Id",
                table: "User",
                column: "UserDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserDetail_UserDetail_Id",
                table: "User",
                column: "UserDetail_Id",
                principalTable: "UserDetail",
                principalColumn: "UserDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
