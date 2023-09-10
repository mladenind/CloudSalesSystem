using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId",
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
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountLicenses_AccountId_LicenseId",
                table: "AccountLicenses",
                columns: new[] { "AccountId", "LicenseId" },
                unique: true);
        }
    }
}
