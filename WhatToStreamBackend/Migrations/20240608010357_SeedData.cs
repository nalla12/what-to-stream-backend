using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "EpisodeCount", "FirstAirYear", "ImageSetId", "ImdbId", "ItemType", "LastAirYear", "Maximum", "Minimum", "OriginalTitle", "Overview", "Rating", "ReleaseYear", "SeasonCount", "ShowType", "Title", "TmdbId" },
                values: new object[] { "968", 12, 2022, null, "tt14169960", "show", 2022, null, null, "지금 우리 학교는", "A high school becomes ground zero for a zombie virus outbreak. Trapped students must fight their way out — or turn into one of the rabid infected.", 76, null, 2, "series", "All of Us Are Dead", "tv/99966" });

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "Id", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "us", 0, "disney", "66", null, null, null, null, null, null, null },
                    { "dk", 0, "netflix", "66", null, null, null, null, null, null, null },
                    { "us", 0, "netflix", "66", null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ShowGenres",
                columns: new[] { "GenreId", "ShowId" },
                values: new object[,]
                {
                    { "action", "968" },
                    { "drama", "968" },
                    { "fantasy", "968" }
                });

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "Id", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "dk", 0, "netflix", "968", null, null, null, null, null, null, null },
                    { "us", 0, "netflix", "968", null, null, null, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShowGenres",
                keyColumns: new[] { "GenreId", "ShowId" },
                keyValues: new object[] { "action", "968" });

            migrationBuilder.DeleteData(
                table: "ShowGenres",
                keyColumns: new[] { "GenreId", "ShowId" },
                keyValues: new object[] { "drama", "968" });

            migrationBuilder.DeleteData(
                table: "ShowGenres",
                keyColumns: new[] { "GenreId", "ShowId" },
                keyValues: new object[] { "fantasy", "968" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 0, "disney", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", 0, "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 0, "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", 0, "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 0, "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: "968");
        }
    }
}
