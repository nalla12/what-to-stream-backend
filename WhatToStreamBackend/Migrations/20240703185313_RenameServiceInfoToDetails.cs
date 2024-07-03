using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameServiceInfoToDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_ServiceInfos_ServiceId",
                table: "StreamingOptions");

            migrationBuilder.DropTable(
                name: "ServiceInfos");

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    HomePage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThemeColorCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceImageSets_ImageSetId",
                        column: x => x.ImageSetId,
                        principalTable: "ServiceImageSets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ServiceDetails",
                columns: new[] { "Id", "HomePage", "ImageSetId", "Name", "ThemeColorCode" },
                values: new object[,]
                {
                    { "apple", "https://tv.apple.com", null, "Apple TV", "#000000" },
                    { "disney", "https://www.disneyplus.com/", null, "Disney+", "#01137c" },
                    { "hbo", "https://play.max.com/", null, "Max", "#002be7" },
                    { "hulu", "https://www.hulu.com/", null, "Hulu", "#1ce783" },
                    { "netflix", "https://netflix.com", null, "Netflix", "#E50914" },
                    { "paramount", "https://www.paramountplus.com/", null, "Paramount+", "#0064FF" },
                    { "peacock", "https://www.peacocktv.com/", null, "Peacock", "#000000" },
                    { "prime", "https://www.primevideo.com/", null, "Prime Video", "#00A8E1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ImageSetId",
                table: "ServiceDetails",
                column: "ImageSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId",
                table: "StreamingOptions",
                column: "ServiceId",
                principalTable: "ServiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId",
                table: "StreamingOptions");

            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageSetId = table.Column<int>(type: "int", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ThemeColorCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInfos_ServiceImageSets_ImageSetId",
                        column: x => x.ImageSetId,
                        principalTable: "ServiceImageSets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ServiceInfos",
                columns: new[] { "Id", "HomePage", "ImageSetId", "Name", "ThemeColorCode" },
                values: new object[,]
                {
                    { "apple", "https://tv.apple.com", null, "Apple TV", "#000000" },
                    { "disney", "https://www.disneyplus.com/", null, "Disney+", "#01137c" },
                    { "netflix", "https://netflix.com", null, "Netflix", "#E50914" },
                    { "prime", "https://www.primevideo.com/", null, "Prime Video", "#00A8E1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_ImageSetId",
                table: "ServiceInfos",
                column: "ImageSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_ServiceInfos_ServiceId",
                table: "StreamingOptions",
                column: "ServiceId",
                principalTable: "ServiceInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
