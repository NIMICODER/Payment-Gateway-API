using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Payment_Gateway.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedMerchant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c51a3b-d1af-4022-a50c-8f12b09e69e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "583a8db5-3ab3-473c-a0a8-cd4557dd03ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce203c7a-eaff-419d-b503-0708a786bdff");

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "746b828a-360e-4c2c-9c03-a8bbbeecc3f1", "c9156fd7-2efa-44ba-ae0a-b3734a68b941", "ThirdParty", "THIRDPARTY" },
                    { "97ea0489-f439-4469-942e-4c27746fef11", "5867bfc5-6141-4743-9b21-99a618ab216b", "Admin", "ADMIN" },
                    { "cb7ea923-d8ff-4aa9-9242-2aabb70a74dd", "ad45b24e-f024-41a8-9d2d-4e0f726ec7d3", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchants");

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
                    { "26c51a3b-d1af-4022-a50c-8f12b09e69e2", "4e6aafae-554c-491d-a68c-3507e4704b0c", "Admin", "ADMIN" },
                    { "583a8db5-3ab3-473c-a0a8-cd4557dd03ec", "620630b3-e43f-47c2-9905-e10a723b3efd", "ThirdParty", "THIRDPARTY" },
                    { "ce203c7a-eaff-419d-b503-0708a786bdff", "a1bf38ce-acda-40c3-bcb7-c1135623cfa1", "User", "USER" }
                });
        }
    }
}
