using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class addCourseLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseLevel",
                columns: table => new
                {
                    CourseLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseLevelTitle = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevel", x => x.CourseLevelId);
                });

            migrationBuilder.InsertData(
                table: "CourseLevel",
                columns: new[] { "CourseLevelId", "CourseLevelTitle" },
                values: new object[] { 1, "مبتدی" });

            migrationBuilder.InsertData(
                table: "CourseLevel",
                columns: new[] { "CourseLevelId", "CourseLevelTitle" },
                values: new object[] { 2, "متوسط" });

            migrationBuilder.InsertData(
                table: "CourseLevel",
                columns: new[] { "CourseLevelId", "CourseLevelTitle" },
                values: new object[] { 3, "پیشرفته" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLevel");
        }
    }
}
