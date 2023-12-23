using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addingTotalSalary_TaxesAndNetSalaryToTableEmployeesAndGetBothOfTaxesAndNetSalaryDependOnTotalSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NetSalary",
                schema: "Blogging",
                table: "Employees",
                type: "Decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSalary",
                schema: "Blogging",
                table: "Employees",
                type: "Decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxes",
                schema: "Blogging",
                table: "Employees",
                type: "Decimal(10,2)",
                nullable: false,
                computedColumnSql: "[TotalSalary] * 0.3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Taxes",
                schema: "Blogging",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                schema: "Blogging",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TotalSalary",
                schema: "Blogging",
                table: "Employees");
        }
    }
}
