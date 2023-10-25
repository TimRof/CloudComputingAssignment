using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations.Listing
{
    /// <inheritdoc />
    public partial class MoreDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PropertyListings",
                keyColumn: "Id",
                keyValue: new Guid("a29d0389-694c-4e1f-9193-4bec8ad62f17"));

            migrationBuilder.InsertData(
                table: "PropertyListings",
                columns: new[] { "Id", "Address", "City", "ImageName", "Price", "Region" },
                values: new object[,]
                {
                    { new Guid("1b2d4d98-fec9-4214-a63a-9a3e6697e1e4"), "123 Test Street", "Test City", "default.png", 500000m, "Test Region" },
                    { new Guid("76d7b3a2-8d3c-48e4-9390-e07c1d5ddddc"), "456 Sample Avenue", "Sample Town", "sample.png", 750000m, "Sample Region" },
                    { new Guid("82d9848d-9575-4710-9963-44dbcaab333a"), "789 Example Road", "Exampleville", "example.png", 600000m, "Example State" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PropertyListings",
                keyColumn: "Id",
                keyValue: new Guid("1b2d4d98-fec9-4214-a63a-9a3e6697e1e4"));

            migrationBuilder.DeleteData(
                table: "PropertyListings",
                keyColumn: "Id",
                keyValue: new Guid("76d7b3a2-8d3c-48e4-9390-e07c1d5ddddc"));

            migrationBuilder.DeleteData(
                table: "PropertyListings",
                keyColumn: "Id",
                keyValue: new Guid("82d9848d-9575-4710-9963-44dbcaab333a"));

            migrationBuilder.InsertData(
                table: "PropertyListings",
                columns: new[] { "Id", "Address", "City", "ImageName", "Price", "Region" },
                values: new object[] { new Guid("a29d0389-694c-4e1f-9193-4bec8ad62f17"), "123 Test Street", "Test City", "default.png", 500000m, "Test Region" });
        }
    }
}
