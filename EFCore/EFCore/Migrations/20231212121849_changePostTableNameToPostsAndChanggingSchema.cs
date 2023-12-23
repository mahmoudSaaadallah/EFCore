using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class changePostTableNameToPostsAndChanggingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "Blogging");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blogs",
                newSchema: "Blogging");

            migrationBuilder.RenameTable(
                name: "AuditEntry",
                newName: "AuditEntry",
                newSchema: "Blogging");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "Blogging",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Blogs",
                schema: "Blogging",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "AuditEntry",
                schema: "Blogging",
                newName: "AuditEntry");
        }
    }
}
