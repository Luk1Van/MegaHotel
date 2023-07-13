using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaHotel.Migrations
{
    /// <inheritdoc />
    public partial class authrizationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "IdRole",
                keyValue: 1,
                column: "Role",
                value: "regularUser");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "IdRole",
                keyValue: 2,
                column: "Role",
                value: "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "IdRole",
                keyValue: 1,
                column: "Role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "IdRole",
                keyValue: 2,
                column: "Role",
                value: 1);
        }
    }
}
