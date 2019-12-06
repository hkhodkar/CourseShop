using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class addCourseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseStatus",
                columns: table => new
                {
                    CourseStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseStatusTitle = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatus", x => x.CourseStatusId);
                });

            migrationBuilder.InsertData(
                table: "CourseStatus",
                columns: new[] { "CourseStatusId", "CourseStatusTitle" },
                values: new object[] { 1, "درحال ثبت نام" });

            migrationBuilder.InsertData(
                table: "CourseStatus",
                columns: new[] { "CourseStatusId", "CourseStatusTitle" },
                values: new object[] { 2, "در حال برگزاری" });

            migrationBuilder.InsertData(
                table: "CourseStatus",
                columns: new[] { "CourseStatusId", "CourseStatusTitle" },
                values: new object[] { 3, "اتمام دوره" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStatus");
        }
    }
}
