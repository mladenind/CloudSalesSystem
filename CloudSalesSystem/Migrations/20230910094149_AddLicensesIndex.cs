using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddLicensesIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId",
                table: "AccountLicenses");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 9, 41, 49, 131, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 9, 41, 49, 131, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 9, 41, 49, 131, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 9, 41, 49, 131, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId",
                table: "AccountLicenses");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 8, 48, 18, 719, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 8, 48, 18, 719, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 8, 48, 18, 719, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 8, 48, 18, 719, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId",
                table: "AccountLicenses",
                column: "AccountId");
        }
    }
}
