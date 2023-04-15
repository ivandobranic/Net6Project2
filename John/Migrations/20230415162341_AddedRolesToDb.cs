using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace John.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69f04b3a-9ca7-44dc-aa8f-852e3250c85a", "5438f737-47c3-4b44-8547-c2097d425468", "Administrator", "ADMINISTRATOR" },
                    { "a35d33a6-c286-498a-bc5e-14b220382472", "03a9dbb5-c403-425f-aeed-511c363f919f", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1822), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1822), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1815), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1816), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1819), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1819), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1549), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1550), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1544), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1547), new DateTime(2023, 4, 15, 16, 23, 41, 351, DateTimeKind.Utc).AddTicks(1547) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69f04b3a-9ca7-44dc-aa8f-852e3250c85a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35d33a6-c286-498a-bc5e-14b220382472");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1106), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1106), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1100), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1101), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1103), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1104), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(926), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(926), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(920), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(923), new DateTime(2023, 4, 15, 16, 4, 18, 863, DateTimeKind.Utc).AddTicks(924) });
        }
    }
}
