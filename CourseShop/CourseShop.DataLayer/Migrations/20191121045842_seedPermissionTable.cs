using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class seedPermissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParrentId", "PermissionNameForAttribute", "PermissionTitle" },
                values: new object[] { 1, null, "admin panel", "پنل مدیریت" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParrentId", "PermissionNameForAttribute", "PermissionTitle" },
                values: new object[] { 2, 1, "user management", "مدیریت کاربران" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParrentId", "PermissionNameForAttribute", "PermissionTitle" },
                values: new object[] { 6, 1, "role management", "مدیریت نقش ها" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "ParrentId", "PermissionNameForAttribute", "PermissionTitle" },
                values: new object[,]
                {
                    { 3, 2, "add user", "اضافه کردن کاربر" },
                    { 4, 2, "edit user", "ویرایش  کاربر" },
                    { 5, 2, "delete user", "حذف  کاربر" },
                    { 7, 6, "add user", "اضافه کردن نقش" },
                    { 8, 6, "edit user", "ویرایش  نقش" },
                    { 9, 6, "delete user", "حذف  نقش" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 1);
        }
    }
}
