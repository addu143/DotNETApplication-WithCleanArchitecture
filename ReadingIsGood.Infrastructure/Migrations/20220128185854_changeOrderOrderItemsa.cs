using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Infrastructure.Migrations
{
    public partial class changeOrderOrderItemsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }
    }
}
