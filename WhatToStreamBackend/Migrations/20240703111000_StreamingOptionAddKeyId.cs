using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class StreamingOptionAddKeyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions");

            migrationBuilder.DeleteData(
                table: "ShowGenres",
                keyColumns: new[] { "GenreId", "ShowId" },
                keyValues: new object[] { "drama", "66" });

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
                keyColumns: new[] { "CountryCode", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", "disney", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: "66");

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: "968");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "StreamingOptions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "StreamingOptions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ShowId",
                table: "StreamingOptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StreamingOptions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_ShowId",
                table: "StreamingOptions",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions");

            migrationBuilder.DropIndex(
                name: "IX_StreamingOptions_ShowId",
                table: "StreamingOptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StreamingOptions");

            migrationBuilder.AlterColumn<string>(
                name: "ShowId",
                table: "StreamingOptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "StreamingOptions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "StreamingOptions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions",
                columns: new[] { "ShowId", "ServiceId", "CountryCode" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "EpisodeCount", "FirstAirYear", "ImageSetId", "ImdbId", "ItemType", "LastAirYear", "OriginalTitle", "Overview", "Rating", "ReleaseYear", "Runtime", "SeasonCount", "ShowType", "Title", "TmdbId" },
                values: new object[,]
                {
                    { "66", null, null, null, "tt0111161", "show", null, "The Shawshank Redemption", "Red (Morgan Freeman) and Andy (Tim Robbins), both incarcerated at Shawshank prison, forge an unlikely bond that will span more than twenty years. Together they discover hope as the ultimate means of survival, in a poignant tale of the human spirit.", 90, 1994, null, null, "movie", "The Shawshank Redemption", "movie/278" },
                    { "968", 12, 2022, null, "tt14169960", "show", 2022, "지금 우리 학교는", "A high school becomes ground zero for a zombie virus outbreak. Trapped students must fight their way out — or turn into one of the rabid infected.", 76, null, null, 2, "series", "All of Us Are Dead", "tv/99966" }
                });

            migrationBuilder.InsertData(
                table: "ShowGenres",
                columns: new[] { "GenreId", "ShowId" },
                values: new object[,]
                {
                    { "drama", "66" },
                    { "action", "968" },
                    { "drama", "968" },
                    { "fantasy", "968" }
                });

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "us", "disney", "66", null, null, null, null, null, null, null },
                    { "dk", "netflix", "66", null, null, null, null, null, null, null },
                    { "us", "netflix", "66", null, null, null, null, null, null, null },
                    { "dk", "netflix", "968", 1693809875L, null, false, "https://www.netflix.com/title/81237994/", null, null, null },
                    { "us", "netflix", "968", 1648576144L, null, true, "https://www.netflix.com/title/81237994/", null, null, null }
                });
        }
    }
}
