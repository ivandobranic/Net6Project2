using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace John.Migrations
{
    /// <inheritdoc />
    public partial class ProductStatusCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69f04b3a-9ca7-44dc-aa8f-852e3250c85a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35d33a6-c286-498a-bc5e-14b220382472");

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abrv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e0dac92-064e-4938-b085-f1e065efcec4", "33ac562b-c6e6-4ad7-852b-0faa44d90737", "Manager", "MANAGER" },
                    { "ebc0349f-2976-44cc-9369-06a401ad0aac", "47e2e624-1f04-4478-9967-f70dae0bb8da", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3413), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3413), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3414) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3406), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3406), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3410), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3410), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3229), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3230), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3224), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3226), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3227) });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "Abrv", "DateCreated", "DateUpdated", "Name", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("3edf9213-e7df-4ab4-a858-21d456b7b450"), "inactive", new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3643), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3643), "Inactive", new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3644) },
                    { new Guid("b4f0e16c-06c1-4eb6-b29c-a84ac9907c52"), "active", new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3621), new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3622), "Active", new DateTime(2023, 5, 13, 13, 58, 45, 178, DateTimeKind.Utc).AddTicks(3622) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e0dac92-064e-4938-b085-f1e065efcec4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebc0349f-2976-44cc-9369-06a401ad0aac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69f04b3a-9ca7-44dc-aa8f-852e3250c85a", "28cb70ea-797d-4d70-b57c-959cac38f71b", "Administrator", "ADMINISTRATOR" },
                    { "a35d33a6-c286-498a-bc5e-14b220382472", "5328e08f-16d9-4786-adc2-fc5a47fddb54", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(680), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(680), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(669), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(670), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(673), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(673), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(367), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(367), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(367) });

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "DateCreated", "DateUpdated", "TimeStamp" },
                values: new object[] { new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(359), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(364), new DateTime(2023, 4, 24, 18, 27, 48, 693, DateTimeKind.Utc).AddTicks(365) });
        }
    }
}
