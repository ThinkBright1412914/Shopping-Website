using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class userId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "505cfa7c-21d8-4b1f-86a3-38190d81f2eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e387636c-cdb9-45a2-84e1-01b13cbfbba3", "ba163679-ab90-4509-815a-acc0d14ce3d6", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e387636c-cdb9-45a2-84e1-01b13cbfbba3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "505cfa7c-21d8-4b1f-86a3-38190d81f2eb", "445182a1-6ff6-42bf-8e18-dd4e0fd24f9d", "admin", "ADMIN" });
        }
    }
}
