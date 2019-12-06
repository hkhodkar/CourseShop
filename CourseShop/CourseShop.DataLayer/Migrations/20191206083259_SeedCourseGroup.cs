using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class SeedCourseGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[,]
                {
                    { 1, "برنامه نویسی موبایل", false, null },
                    { 5, "برنامه نویسی وب", false, null },
                    { 10, "برنامه نویسی تحت ویندوز", false, null },
                    { 14, "بانک های اطلاعاتی", false, null },
                    { 18, "طراحی سایت", false, null }
                });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[,]
                {
                    { 2, "زامارین Xamarin", false, 1 },
                    { 3, "React Native", false, 1 },
                    { 4, "زامارین Xamarin", false, 1 },
                    { 6, "ASP.net WebForms", false, 5 },
                    { 7, "ASP.net MVC", false, 5 },
                    { 8, "PHP MVC", false, 5 },
                    { 9, "ASP.net Core", false, 5 },
                    { 11, "سی شارپ C#", false, 10 },
                    { 12, "جاوا Java", false, 10 },
                    { 13, "Node JS", false, 10 }
                });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 15, "SQL Server", false, 13 });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 16, "No SQL", false, 13 });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 17, "My SQL", false, 13 });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 19, "Bootstrap", false, 17 });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 20, "JQuery", false, 17 });

            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 21, "Java Script", false, 17 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 10);
        }
    }
}
