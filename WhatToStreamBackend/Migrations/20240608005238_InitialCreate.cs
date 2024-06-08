using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorizontalImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    W360 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W480 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W720 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W1080 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W1440 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorizontalImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceImageSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LightThemeImage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DarkThemeImage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    WhiteImage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceImageSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerticalImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    W240 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W360 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W480 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W600 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    W720 = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerticalImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThemeColorCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageSetId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ShowImageSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerticalPosterId = table.Column<int>(type: "int", nullable: true),
                    HorizontalPosterId = table.Column<int>(type: "int", nullable: true),
                    VerticalBackdropId = table.Column<int>(type: "int", nullable: true),
                    HorizontalBackdropId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowImageSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowImageSets_HorizontalImages_HorizontalBackdropId",
                        column: x => x.HorizontalBackdropId,
                        principalTable: "HorizontalImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowImageSets_HorizontalImages_HorizontalPosterId",
                        column: x => x.HorizontalPosterId,
                        principalTable: "HorizontalImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowImageSets_VerticalImages_VerticalBackdropId",
                        column: x => x.VerticalBackdropId,
                        principalTable: "VerticalImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowImageSets_VerticalImages_VerticalPosterId",
                        column: x => x.VerticalPosterId,
                        principalTable: "VerticalImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShowType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TmdbId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    FirstAirYear = table.Column<int>(type: "int", nullable: true),
                    LastAirYear = table.Column<int>(type: "int", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Minimum = table.Column<int>(type: "int", nullable: true),
                    Maximum = table.Column<int>(type: "int", nullable: true),
                    SeasonCount = table.Column<int>(type: "int", nullable: true),
                    EpisodeCount = table.Column<int>(type: "int", nullable: true),
                    ImageSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_ShowImageSets_ImageSetId",
                        column: x => x.ImageSetId,
                        principalTable: "ShowImageSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowGenres",
                columns: table => new
                {
                    ShowId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowGenres", x => new { x.ShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ShowGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowGenres_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StreamingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    VideoLink = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Quality = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ExpiresSoon = table.Column<bool>(type: "bit", nullable: true),
                    ExpiresOn = table.Column<int>(type: "int", nullable: true),
                    AvailableSince = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingOptions", x => new { x.Id, x.ShowId, x.ServiceId, x.CountryCode });
                    table.ForeignKey(
                        name: "FK_StreamingOptions_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StreamingOptions_ServiceInfos_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StreamingOptions_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryCode", "Name" },
                values: new object[,]
                {
                    { "dk", "Denmark" },
                    { "gb", "United Kingdom" },
                    { "jp", "Japan" },
                    { "kr", "South Korea" },
                    { "se", "Sweden" },
                    { "us", "United States" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "action", "Action" },
                    { "adventure", "Adventure" },
                    { "animation", "Animation" },
                    { "comedy", "Comedy" },
                    { "crime", "Crime" },
                    { "documentary", "Documentary" },
                    { "drama", "Drama" },
                    { "family", "Family" },
                    { "fantasy", "Fantasy" },
                    { "history", "History" },
                    { "horror", "Horror" },
                    { "music", "Music" },
                    { "mystery", "Mystery" },
                    { "news", "News" },
                    { "reality", "Reality" },
                    { "romance", "Romance" },
                    { "scifi", "Science Fiction" },
                    { "talk", "Talk Show" },
                    { "thriller", "Thriller" },
                    { "war", "War" },
                    { "western", "Western" }
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

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "EpisodeCount", "FirstAirYear", "ImageSetId", "ImdbId", "ItemType", "LastAirYear", "Maximum", "Minimum", "OriginalTitle", "Overview", "Rating", "ReleaseYear", "SeasonCount", "ShowType", "Title", "TmdbId" },
                values: new object[] { "66", null, null, null, "tt0111161", "show", null, null, null, "The Shawshank Redemption", "Red (Morgan Freeman) and Andy (Tim Robbins), both incarcerated at Shawshank prison, forge an unlikely bond that will span more than twenty years. Together they discover hope as the ultimate means of survival, in a poignant tale of the human spirit.", 90, 1994, null, "movie", "The Shawshank Redemption", "movie/278" });

            migrationBuilder.InsertData(
                table: "ShowGenres",
                columns: new[] { "GenreId", "ShowId" },
                values: new object[] { "drama", "66" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInfos_ImageSetId",
                table: "ServiceInfos",
                column: "ImageSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowGenres_GenreId",
                table: "ShowGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowImageSets_HorizontalBackdropId",
                table: "ShowImageSets",
                column: "HorizontalBackdropId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowImageSets_HorizontalPosterId",
                table: "ShowImageSets",
                column: "HorizontalPosterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowImageSets_VerticalBackdropId",
                table: "ShowImageSets",
                column: "VerticalBackdropId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowImageSets_VerticalPosterId",
                table: "ShowImageSets",
                column: "VerticalPosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ImageSetId",
                table: "Shows",
                column: "ImageSetId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_CountryCode",
                table: "StreamingOptions",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_ServiceId",
                table: "StreamingOptions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_ShowId",
                table: "StreamingOptions",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowGenres");

            migrationBuilder.DropTable(
                name: "StreamingOptions");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ServiceInfos");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "ServiceImageSets");

            migrationBuilder.DropTable(
                name: "ShowImageSets");

            migrationBuilder.DropTable(
                name: "HorizontalImages");

            migrationBuilder.DropTable(
                name: "VerticalImages");
        }
    }
}
