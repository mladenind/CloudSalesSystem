using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddExpDateToIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 48, 13, 359, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 48, 13, 359, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 48, 13, 359, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 48, 13, 359, DateTimeKind.Utc).AddTicks(6852));

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive_ExpirationDate",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId", "IsActive", "ExpirationDate" },
                unique: true,
                filter: "[ExpirationDate] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive_ExpirationDate",
                table: "AccountLicenses");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 29, 41, 140, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 29, 41, 140, DateTimeKind.Utc).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 29, 41, 140, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 10, 10, 29, 41, 140, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId", "IsActive" },
                unique: true);
        }
    }
}
