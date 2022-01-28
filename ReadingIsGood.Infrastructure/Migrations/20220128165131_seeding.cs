using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Infrastructure.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Electronics" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId", "Quantity", "SKU", "Sold" },
                values: new object[] { 1, "IPhone", 1100f, 1, 100, "IPP", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId", "Quantity", "SKU", "Sold" },
                values: new object[] { 2, "Samsung A20", 2000f, 1, 200, "S20", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId", "Quantity", "SKU", "Sold" },
                values: new object[] { 3, "Guitar", 500f, 1, 300, "GUI", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId", "Quantity", "SKU", "Sold" },
                values: new object[] { 4, "Microsoft Keyboard", 200f, 1, 50, "MK", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductCategoryId", "Quantity", "SKU", "Sold" },
                values: new object[] { 5, "Washing Machine", 877f, 1, 50, "WMA", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
