using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace John.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsActive", "Name", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4585), new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4585), true, "DJ Controllers", new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4585) },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4579), new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4582), true, "TV", new DateTime(2023, 4, 3, 18, 3, 16, 109, DateTimeKind.Utc).AddTicks(4582) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "IsActive", "Name", "Price", "ProductCategoryId", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Traktor", 35m, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Samsung", 26m, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "LG", 30m, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
