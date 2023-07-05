using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class order2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8d932b-4fd4-4347-aa17-ad58b456003a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "505cfa7c-21d8-4b1f-86a3-38190d81f2eb", "445182a1-6ff6-42bf-8e18-dd4e0fd24f9d", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "505cfa7c-21d8-4b1f-86a3-38190d81f2eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b8d932b-4fd4-4347-aa17-ad58b456003a", "fcfc2cf8-9bdd-400f-8e24-b7d14267e2c9", "admin", "ADMIN" });
        }
    }
}
