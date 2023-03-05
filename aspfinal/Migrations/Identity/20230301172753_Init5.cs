using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspfinal.Migrations.Identity
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "userProfiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_UserId",
                table: "userProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_AspNetUsers_UserId",
                table: "userProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_AspNetUsers_UserId",
                table: "userProfiles");

            migrationBuilder.DropIndex(
                name: "IX_userProfiles_UserId",
                table: "userProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "userProfiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
