using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zelis.Api.Migrations
{
    /// <inheritdoc />
    public partial class models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communications_CommunicationTypes_TypeCode",
                table: "Communications");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationTypeStatuses_CommunicationTypes_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationTypeStatuses",
                table: "CommunicationTypeStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CommunicationTypeStatuses_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationTypes",
                table: "CommunicationTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communications",
                table: "Communications");

            migrationBuilder.DropColumn(
                name: "CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses");

            migrationBuilder.RenameTable(
                name: "CommunicationTypeStatuses",
                newName: "CommunicationTypeStatus");

            migrationBuilder.RenameTable(
                name: "CommunicationTypes",
                newName: "CommunicationType");

            migrationBuilder.RenameTable(
                name: "Communications",
                newName: "Communication");

            migrationBuilder.RenameIndex(
                name: "IX_Communications_TypeCode",
                table: "Communication",
                newName: "IX_Communication_TypeCode");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CommunicationTypeStatus",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCode",
                table: "CommunicationTypeStatus",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "CommunicationTypeStatus",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CommunicationType",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "CommunicationType",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "Communication",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Communication",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationTypeStatus",
                table: "CommunicationTypeStatus",
                columns: new[] { "TypeCode", "StatusCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType",
                column: "TypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communication",
                table: "Communication",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommunicationStatusHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    OccurredUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationStatusHistory_Communication_CommunicationId",
                        column: x => x.CommunicationId,
                        principalTable: "Communication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationStatusHistory_CommunicationId",
                table: "CommunicationStatusHistory",
                column: "CommunicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_CommunicationType_TypeCode",
                table: "Communication",
                column: "TypeCode",
                principalTable: "CommunicationType",
                principalColumn: "TypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypeStatus_CommunicationType_TypeCode",
                table: "CommunicationTypeStatus",
                column: "TypeCode",
                principalTable: "CommunicationType",
                principalColumn: "TypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communication_CommunicationType_TypeCode",
                table: "Communication");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunicationTypeStatus_CommunicationType_TypeCode",
                table: "CommunicationTypeStatus");

            migrationBuilder.DropTable(
                name: "CommunicationStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationTypeStatus",
                table: "CommunicationTypeStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunicationType",
                table: "CommunicationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communication",
                table: "Communication");

            migrationBuilder.RenameTable(
                name: "CommunicationTypeStatus",
                newName: "CommunicationTypeStatuses");

            migrationBuilder.RenameTable(
                name: "CommunicationType",
                newName: "CommunicationTypes");

            migrationBuilder.RenameTable(
                name: "Communication",
                newName: "Communications");

            migrationBuilder.RenameIndex(
                name: "IX_Communication_TypeCode",
                table: "Communications",
                newName: "IX_Communications_TypeCode");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CommunicationTypeStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "StatusCode",
                table: "CommunicationTypeStatuses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "CommunicationTypeStatuses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CommunicationTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "CommunicationTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "TypeCode",
                table: "Communications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Communications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationTypeStatuses",
                table: "CommunicationTypeStatuses",
                columns: new[] { "TypeCode", "StatusCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunicationTypes",
                table: "CommunicationTypes",
                column: "TypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communications",
                table: "Communications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTypeStatuses_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses",
                column: "CommunicationTypeTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_CommunicationTypes_TypeCode",
                table: "Communications",
                column: "TypeCode",
                principalTable: "CommunicationTypes",
                principalColumn: "TypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypeStatuses_CommunicationTypes_CommunicationTypeTypeCode",
                table: "CommunicationTypeStatuses",
                column: "CommunicationTypeTypeCode",
                principalTable: "CommunicationTypes",
                principalColumn: "TypeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
