using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class adminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Token", "UserName" },
                values: new object[] { "0VT5s7zLvBycKO1sFrhtcBIQICNCmqPspfmuWpBESX/XSKx3", null, "AdminMasterUser01" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Token", "UserName" },
                values: new object[] { "wasd123", "123abc", "OgMaster001" });
        }
    }
}
