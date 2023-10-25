using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class MoreDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e0783c19-f263-4c27-81a2-39a77325361a"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "MonthlyIncome", "Name" },
                values: new object[,]
                {
                    { new Guid("5dd114bb-636c-4dc9-aa2d-d1be62608a87"), "test1@example.com", 1000m, "Test Name 1" },
                    { new Guid("c4bd8356-d8e6-4236-b113-9503fef2a09c"), "test3@example.com", 3000m, "Test Name 3" },
                    { new Guid("c84f7d42-a38c-4f2a-8218-f1ddca2ab6d3"), "test2@example.com", 2000m, "Test Name 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5dd114bb-636c-4dc9-aa2d-d1be62608a87"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c4bd8356-d8e6-4236-b113-9503fef2a09c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c84f7d42-a38c-4f2a-8218-f1ddca2ab6d3"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "MonthlyIncome", "Name" },
                values: new object[] { new Guid("e0783c19-f263-4c27-81a2-39a77325361a"), "test@example.com", 1000m, "Test Name" });
        }
    }
}
