using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddingTheActorMovieTableByMyself : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                schema: "Blogging",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                schema: "Blogging",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                schema: "Blogging",
                table: "ActorMovie",
                column: "ActorId",
                principalSchema: "Blogging",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                schema: "Blogging",
                table: "ActorMovie",
                column: "MovieId",
                principalSchema: "Blogging",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                schema: "Blogging",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                schema: "Blogging",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "ActorsId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                schema: "Blogging",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsId",
                schema: "Blogging",
                table: "ActorMovie",
                column: "ActorsId",
                principalSchema: "Blogging",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MoviesId",
                schema: "Blogging",
                table: "ActorMovie",
                column: "MoviesId",
                principalSchema: "Blogging",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
