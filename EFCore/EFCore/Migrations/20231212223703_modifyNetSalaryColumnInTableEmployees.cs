using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class modifyNetSalaryColumnInTableEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                schema: "Blogging",
                table: "Employees",
                type: "Decimal(10,2)",
                nullable: false,
                computedColumnSql: "[TotalSalary] - (0.3 * [TotalSalary])",
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                schema: "Blogging",
                table: "Employees",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)",
                oldComputedColumnSql: "[TotalSalary] - (0.3 * [TotalSalary])");
        }
    }
}
