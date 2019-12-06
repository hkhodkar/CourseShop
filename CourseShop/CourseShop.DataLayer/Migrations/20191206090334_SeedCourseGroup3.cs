using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class SeedCourseGroup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseGroup",
                columns: new[] { "CourseGroupId", "CourseGroupTitle", "IsDeleted", "ParentId" },
                values: new object[] { 4, "زامارین Xamarin", false, 1 });
        }
    }
}
