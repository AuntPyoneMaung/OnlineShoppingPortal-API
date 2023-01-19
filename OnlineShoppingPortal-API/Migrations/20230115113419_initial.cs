using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardDetail",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNo = table.Column<int>(type: "int", nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetail", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Segment",
                columns: table => new
                {
                    SegmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segment", x => x.SegmentId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Segment_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segment",
                        principalColumn: "SegmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                    table.ForeignKey(
                        name: "FK_Brand_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCustId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerCustId",
                        column: x => x.CustomerCustId,
                        principalTable: "Customer",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandProducts",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandProducts", x => new { x.BrandId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BrandProducts_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CardDetailsCardId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_CardDetail_CardDetailsCardId",
                        column: x => x.CardDetailsCardId,
                        principalTable: "CardDetail",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Segment",
                columns: new[] { "SegmentId", "SegmentName" },
                values: new object[,]
                {
                    { 101, "Organic" },
                    { 102, "Halal" },
                    { 103, "On-the-Go" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "EmailId", "FirstName", "IsAdmin", "LastName", "Password", "UserName" },
                values: new object[] { 1, "adminuser@mail.com", "Master", true, "User", "wasd123", "OgMaster001" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "SegmentId" },
                values: new object[,]
                {
                    { 101, "Vegetables", 101 },
                    { 102, "Fruits", 101 },
                    { 103, "Finger Food", 103 },
                    { 104, "Drinks", 103 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CategoryId",
                table: "Brand",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandProducts_ProductId",
                table: "BrandProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerCustId",
                table: "Cart",
                column: "CustomerCustId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SegmentId",
                table: "Category",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CardDetailsCardId",
                table: "Payment",
                column: "CardDetailsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CartId",
                table: "Payment",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandProducts");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "CardDetail");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Segment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
