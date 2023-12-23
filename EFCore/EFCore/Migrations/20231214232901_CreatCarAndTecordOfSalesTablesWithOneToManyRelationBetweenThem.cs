using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CreatCarAndTecordOfSalesTablesWithOneToManyRelationBetweenThem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "Blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.UniqueConstraint("AK_Cars_LicensePlate", x => x.LicensePlate);
                });

            migrationBuilder.CreateTable(
                name: "RecordOfSales",
                schema: "Blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOfSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordOfSales_Cars_CarLicensePlate",
                        column: x => x.CarLicensePlate,
                        principalSchema: "Blogging",
                        principalTable: "Cars",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOfSales_CarLicensePlate",
                schema: "Blogging",
                table: "RecordOfSales",
                column: "CarLicensePlate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordOfSales",
                schema: "Blogging");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "Blogging");
        }
    }
}
