using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addingNationaltyTableWithARelationOfOneToONeWithAcotrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorNationalityId",
                schema: "Blogging",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Nationalities",
                schema: "Blogging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_ActorNationalityId",
                schema: "Blogging",
                table: "Actors",
                column: "ActorNationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Nationalities_ActorNationalityId",
                schema: "Blogging",
                table: "Actors",
                column: "ActorNationalityId",
                principalSchema: "Blogging",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Nationalities_ActorNationalityId",
                schema: "Blogging",
                table: "Actors");

            migrationBuilder.DropTable(
                name: "Nationalities",
                schema: "Blogging");

            migrationBuilder.DropIndex(
                name: "IX_Actors_ActorNationalityId",
                schema: "Blogging",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorNationalityId",
                schema: "Blogging",
                table: "Actors");
        }
    }
}
