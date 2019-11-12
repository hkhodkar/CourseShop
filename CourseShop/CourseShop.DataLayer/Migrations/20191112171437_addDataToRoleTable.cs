using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class addDataToRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsDeleted", "RoleTitle" },
                values: new object[] { 1, false, "مدیر سایت" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsDeleted", "RoleTitle" },
                values: new object[] { 2, false, "استاد" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);
        }
    }
}
