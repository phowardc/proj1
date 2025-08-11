using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zelis.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCommunicationAndTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Communication",
                columns: new[] { "Id", "CurrentStatus", "LastUpdatedUtc", "Title", "TypeCode" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome Email", "email" },
                    { new Guid("11111111-1111-1211-1111-111111111111"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Promo SMS", "sms" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Communication",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Communication",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1211-1111-111111111111"));
        }
    }
}
