using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloudSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerAndAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Email", "Name" },
                values: new object[] { 1, new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9486), "supercustomer@crayon.com", "Super Customer" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9569), 1, "First Test Account" },
                    { 2, new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9570), 1, "Second Test Account" },
                    { 3, new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9571), 1, "Second Test Account" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
