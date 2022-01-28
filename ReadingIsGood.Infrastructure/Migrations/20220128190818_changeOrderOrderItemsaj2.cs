using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Infrastructure.Migrations
{
    public partial class changeOrderOrderItemsaj2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "OrderItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "OrderItems");
        }
    }
}
