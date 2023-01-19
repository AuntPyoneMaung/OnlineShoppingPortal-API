using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class userAttributeModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Role",
                value: "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "IsAdmin",
                value: true);
        }
    }
}
