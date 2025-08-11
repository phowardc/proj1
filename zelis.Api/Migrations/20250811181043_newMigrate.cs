using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zelis.Api.Migrations
{
    /// <inheritdoc />
    public partial class newMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus",
                type: "nvarchar(64)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "failed", "email" },
                column: "CommunicationTypeTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "sent", "email" },
                column: "CommunicationTypeTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "delivered", "sms" },
                column: "CommunicationTypeTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "CommunicationTypeStatus",
                keyColumns: new[] { "StatusCode", "TypeCode" },
                keyValues: new object[] { "undelivered", "sms" },
                column: "CommunicationTypeTypeCode",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTypeStatus_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus",
                column: "CommunicationTypeTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypeStatus_CommunicationType_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus",
                column: "CommunicationTypeTypeCode",
                principalTable: "CommunicationType",
                principalColumn: "TypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationTypeStatus_CommunicationType_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus");

            migrationBuilder.DropIndex(
                name: "IX_CommunicationTypeStatus_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus");

            migrationBuilder.DropColumn(
                name: "CommunicationTypeTypeCode",
                table: "CommunicationTypeStatus");
        }
    }
}
