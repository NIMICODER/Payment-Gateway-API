using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Payment_Gateway.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedMerchantRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746b828a-360e-4c2c-9c03-a8bbbeecc3f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ea0489-f439-4469-942e-4c27746fef11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb7ea923-d8ff-4aa9-9242-2aabb70a74dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24c0be07-b007-4cfb-a4d5-bb9b432aa376", "d3901ecb-feff-43a0-affe-d771d4ac2d1b", "User", "USER" },
                    { "948ea9b7-8d28-4f44-ba68-7e6d68f6569c", "caa09044-1deb-41b6-81a3-71e2b14d3063", "Merchant", "MERCHANT" },
                    { "96f5b50f-6e34-4a3b-b9d3-15b8567a9425", "f24df38c-f03a-4163-9988-2448e666222c", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c0be07-b007-4cfb-a4d5-bb9b432aa376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "948ea9b7-8d28-4f44-ba68-7e6d68f6569c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96f5b50f-6e34-4a3b-b9d3-15b8567a9425");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "746b828a-360e-4c2c-9c03-a8bbbeecc3f1", "c9156fd7-2efa-44ba-ae0a-b3734a68b941", "ThirdParty", "THIRDPARTY" },
                    { "97ea0489-f439-4469-942e-4c27746fef11", "5867bfc5-6141-4743-9b21-99a618ab216b", "Admin", "ADMIN" },
                    { "cb7ea923-d8ff-4aa9-9242-2aabb70a74dd", "ad45b24e-f024-41a8-9d2d-4e0f726ec7d3", "User", "USER" }
                });
        }
    }
}
