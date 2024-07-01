using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhatToStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRuntimeRemoveUnusedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions");

            migrationBuilder.DropIndex(
                name: "IX_StreamingOptions_ShowId",
                table: "StreamingOptions");

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyColumnTypes: new[] { "nvarchar(2)", "int", "nvarchar(255)", "nvarchar(50)" },
                keyValues: new object[] { "dk", 0, "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyColumnTypes: new[] { "nvarchar(2)", "int", "nvarchar(255)", "nvarchar(50)" },
                keyValues: new object[] { "us", 1, "netflix", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyColumnTypes: new[] { "nvarchar(2)", "int", "nvarchar(255)", "nvarchar(50)" },
                keyValues: new object[] { "us", 2, "disney", "66" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyColumnTypes: new[] { "nvarchar(2)", "int", "nvarchar(255)", "nvarchar(50)" },
                keyValues: new object[] { "dk", 3, "netflix", "968" });

            migrationBuilder.DeleteData(
                table: "StreamingOptions",
                keyColumns: new[] { "CountryCode", "Id", "ServiceId", "ShowId" },
                keyColumnTypes: new[] { "nvarchar(2)", "int", "nvarchar(255)", "nvarchar(50)" },
                keyValues: new object[] { "us", 4, "netflix", "968" });

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StreamingOptions");

            migrationBuilder.DropColumn(
                name: "Maximum",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "Minimum",
                table: "Shows",
                newName: "Runtime");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "StreamingOptions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "StreamingOptions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "ShowId",
                table: "StreamingOptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceInfos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions",
                columns: new[] { "ShowId", "ServiceId", "CountryCode" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions");

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

            migrationBuilder.RenameColumn(
                name: "Runtime",
                table: "Shows",
                newName: "Minimum");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "StreamingOptions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2)
                .Annotation("Relational:ColumnOrder", 3)
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
                .Annotation("Relational:ColumnOrder", 2)
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
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StreamingOptions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Maximum",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ServiceInfos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreamingOptions",
                table: "StreamingOptions",
                columns: new[] { "Id", "ShowId", "ServiceId", "CountryCode" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: "66",
                column: "Maximum",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: "968",
                column: "Maximum",
                value: null);

            migrationBuilder.InsertData(
                table: "StreamingOptions",
                columns: new[] { "CountryCode", "Id", "ServiceId", "ShowId", "AvailableSince", "ExpiresOn", "ExpiresSoon", "Link", "Quality", "Type", "VideoLink" },
                values: new object[,]
                {
                    { "dk", 0, "netflix", "66", null, null, null, null, null, null, null },
                    { "us", 1, "netflix", "66", null, null, null, null, null, null, null },
                    { "us", 2, "disney", "66", null, null, null, null, null, null, null },
                    { "dk", 3, "netflix", "968", 1693809875L, null, false, "https://www.netflix.com/title/81237994/", null, null, null },
                    { "us", 4, "netflix", "968", 1648576144L, null, true, "https://www.netflix.com/title/81237994/", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreamingOptions_ShowId",
                table: "StreamingOptions",
                column: "ShowId");
        }
    }
}
