using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameColToCountryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_Countries_CountryCode1",
                table: "StreamingOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId_CountryCode",
                table: "StreamingOptions");

            migrationBuilder.DropIndex(
                name: "IX_StreamingOptions_CountryCode1",
                table: "StreamingOptions");

            migrationBuilder.DropColumn(
                name: "CountryCode1",
                table: "StreamingOptions");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "StreamingOptions",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_StreamingOptions_ServiceId_CountryCode",
                table: "StreamingOptions",
                newName: "IX_StreamingOptions_ServiceId_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_CountryId",
                table: "StreamingOptions",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_Countries_CountryId",
                table: "StreamingOptions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId_CountryId",
                table: "StreamingOptions",
                columns: new[] { "ServiceId", "CountryId" },
                principalTable: "ServiceDetails",
                principalColumns: new[] { "Id", "CountryCode" },
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_Countries_CountryId",
                table: "StreamingOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId_CountryId",
                table: "StreamingOptions");

            migrationBuilder.DropIndex(
                name: "IX_StreamingOptions_CountryId",
                table: "StreamingOptions");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "StreamingOptions",
                newName: "CountryCode");

            migrationBuilder.RenameIndex(
                name: "IX_StreamingOptions_ServiceId_CountryId",
                table: "StreamingOptions",
                newName: "IX_StreamingOptions_ServiceId_CountryCode");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode1",
                table: "StreamingOptions",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_CountryCode1",
                table: "StreamingOptions",
                column: "CountryCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_Countries_CountryCode1",
                table: "StreamingOptions",
                column: "CountryCode1",
                principalTable: "Countries",
                principalColumn: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamingOptions_ServiceDetails_ServiceId_CountryCode",
                table: "StreamingOptions",
                columns: new[] { "ServiceId", "CountryCode" },
                principalTable: "ServiceDetails",
                principalColumns: new[] { "Id", "CountryCode" },
                onDelete: ReferentialAction.NoAction);
        }
    }
}
