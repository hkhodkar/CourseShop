using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class SeedCourseGroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 15,
                column: "ParentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 16,
                column: "ParentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 17,
                column: "ParentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 19,
                column: "ParentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 20,
                column: "ParentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 21,
                column: "ParentId",
                value: 18);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 15,
                column: "ParentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 16,
                column: "ParentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 17,
                column: "ParentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 19,
                column: "ParentId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 20,
                column: "ParentId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "CourseGroup",
                keyColumn: "CourseGroupId",
                keyValue: 21,
                column: "ParentId",
                value: 17);
        }
    }
}
