using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class userCustomerCombined : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customer_CustomerCustId",
                table: "Cart");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerCustId",
                table: "Cart",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CustomerCustId",
                table: "Cart",
                newName: "IX_Cart_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZIP",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address1", "Address2", "City", "Phone", "State", "ZIP" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_CustomerId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "User");

            migrationBuilder.DropColumn(
                name: "City",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.DropColumn(
                name: "State",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Cart",
                newName: "CustomerCustId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                newName: "IX_Cart_CustomerCustId");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustId);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customer_CustomerCustId",
                table: "Cart",
                column: "CustomerCustId",
                principalTable: "Customer",
                principalColumn: "CustId");
        }
    }
}
