using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zelis.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CommunicationType",
                columns: new[] { "TypeCode", "DisplayName" },
                values: new object[,]
                {
                    { "email", "Email" },
                    { "sms", "SMS" }
                });

            migrationBuilder.InsertData(
                table: "CommunicationTypeStatus",
                columns: new[] { "StatusCode", "TypeCode", "Description" },
                values: new object[,]
                {
                    { "failed", "email", "Email Failed" },
                    { "sent", "email", "Email Sent" },
                    { "delivered", "sms", "SMS Delivered" },
                    { "undelivered", "sms", "SMS Undelivered" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "failed", "email" });

            migrationBuilder.DeleteData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "sent", "email" });

            migrationBuilder.DeleteData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "delivered", "sms" });

            migrationBuilder.DeleteData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "undelivered", "sms" });

            migrationBuilder.DeleteData(
                table: "CommunicationType",
                keyColumn: "TypeCode",
                keyValue: "email");

            migrationBuilder.DeleteData(
                table: "CommunicationType",
                keyColumn: "TypeCode",
                keyValue: "sms");
        }
    }
}
