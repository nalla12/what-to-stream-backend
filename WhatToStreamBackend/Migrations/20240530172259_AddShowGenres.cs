using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddShowGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Shows_ShowId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_ShowId",
                table: "Genre",
                newName: "IX_Genre_ShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShowGenre",
                columns: table => new
                {
                    ShowId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowGenre", x => new { x.ShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ShowGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowGenre_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShowGenre",
                columns: new[] { "GenreId", "ShowId" },
                values: new object[] { "drama", "66" });

            migrationBuilder.CreateIndex(
                name: "IX_ShowGenre_GenreId",
                table: "ShowGenre",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Shows_ShowId",
                table: "Genre",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Shows_ShowId",
                table: "Genre");

            migrationBuilder.DropTable(
                name: "ShowGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_ShowId",
                table: "Genres",
                newName: "IX_Genres_ShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Shows_ShowId",
                table: "Genres",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");
        }
    }
}
