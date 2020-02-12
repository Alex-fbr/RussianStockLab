using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSLab.DAL.Migrations
{
    public partial class _00InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECID = table.Column<string>(nullable: true),
                    SHORTNAME = table.Column<string>(nullable: true),
                    OpenPrice = table.Column<double>(nullable: false),
                    ClosePrice = table.Column<double>(nullable: false),
                    LowPrice = table.Column<double>(nullable: false),
                    HighPrice = table.Column<double>(nullable: false),
                    WaPrice = table.Column<double>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    IndustrialSector = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "dbo");
        }
    }
}
