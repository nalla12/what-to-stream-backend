using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class StreamingOptionDatesLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 0, "disney", "66" });

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

            migrationBuilder.AlterColumn<long>(
                name: "ExpiresOn",
                table: "StreamingOptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AvailableSince",
                table: "StreamingOptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", 0, "netflix", "66" },
                columns: new[] { "AvailableSince", "ExpiresOn" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "Id", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "us", 1, "netflix", "66", null, null, null, null, null, null, null },
                    { "us", 2, "disney", "66", null, null, null, null, null, null, null },
                    { "dk", 3, "netflix", "968", 1693809875L, null, false, "https://www.netflix.com/title/81237994/", null, null, null },
                    { "us", 4, "netflix", "968", 1648576144L, null, true, "https://www.netflix.com/title/81237994/", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 1, "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 2, "disney", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", 3, "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "us", 4, "netflix", "968" });

            migrationBuilder.AlterColumn<int>(
                name: "ExpiresOn",
                table: "StreamingOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvailableSince",
                table: "StreamingOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyValues: new object[] { "dk", 0, "netflix", "66" },
                columns: new[] { "AvailableSince", "ExpiresOn" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "Id", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "us", 0, "disney", "66", null, null, null, null, null, null, null },
                    { "us", 0, "netflix", "66", null, null, null, null, null, null, null },
                    { "dk", 0, "netflix", "968", null, null, null, null, null, null, null },
                    { "us", 0, "netflix", "968", null, null, null, null, null, null, null }
                });
        }
    }
}
