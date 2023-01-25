using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class productAndBrandSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandId", "BrandName", "CategoryId" },
                values: new object[,]
                {
                    { 1, "Pasar", 101 },
                    { 2, "TasteMaxx", 101 },
                    { 3, "FairP", 102 },
                    { 4, "Deli", 103 },
                    { 5, "Nutri GO", 103 },
                    { 6, "Quechzxc", 104 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "ProductDescription", "ProductModel", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "A green vegetable", "66A", "Leek", 30 },
                    { 2, "An orange edible, safe for consumption", "67B", "Carrot", 50 },
                    { 3, "A red, juicy and sweet fruit", "68X", "Apple", 70 },
                    { 4, "Top grade, Japan Import, perishable, good for gifts", "69Z", "Honey Dew", 5000 },
                    { 5, "(1kg) Savory, munchable, to-go, kids love it!", "70S", "Nugget", 300 },
                    { 6, "Mini-ones for quick breakfast on busy days", "71M", "Sandwich", 250 },
                    { 7, "For guilty diet, sweet, no sugar added", "72L", "Diet Coke", 30 },
                    { 8, "Just like Coke but blue can, maybe better", "73P", "Pepsi", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);
        }
    }
}
