using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToIndexUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId", "IsActive" },
                unique: true,
                filter: "[IsActive] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AccountLicenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId_IsActive",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId", "IsActive" },
                unique: true,
                filter: "[IsActive] IS NOT NULL");
        }
    }
}
