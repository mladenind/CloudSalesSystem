using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AccountLicenses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AccountLicenses");
        }
    }
}
