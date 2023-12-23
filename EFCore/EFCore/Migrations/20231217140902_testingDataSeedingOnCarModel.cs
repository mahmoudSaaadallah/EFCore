using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class testingDataSeedingOnCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Blogging",
                table: "Cars",
                columns: new[] { "Id", "LicensePlate", "Model" },
                values: new object[,]
                {
                    { 1, "307", "BMW" },
                    { 2, "703", "Audy" },
                    { 3, "901", "KIA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Blogging",
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Blogging",
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Blogging",
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
