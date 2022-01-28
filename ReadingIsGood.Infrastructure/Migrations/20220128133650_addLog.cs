using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingIsGood.Infrastructure.Migrations
{
    public partial class addLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LogLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortMessage = table.Column<string>(type: "TEXT", nullable: true),
                    FullMessage = table.Column<string>(type: "TEXT", nullable: true),
                    PageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ReferrerUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
