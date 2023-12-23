using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class changingTheNameOfPrimaryKeyForBookSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "Blogging",
                table: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookNumber",
                schema: "Blogging",
                table: "Books",
                column: "bookNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookNumber",
                schema: "Blogging",
                table: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "Blogging",
                table: "Books",
                column: "bookNumber");
        }
    }
}
