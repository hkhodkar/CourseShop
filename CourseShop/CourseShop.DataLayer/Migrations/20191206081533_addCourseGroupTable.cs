using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class addCourseGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "CourseGroup",
                columns: table => new
                {
                    CourseGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseGroupTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroup", x => x.CourseGroupId);
                    table.ForeignKey(
                        name: "FK_CourseGroup_CourseGroup_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CourseGroup",
                        principalColumn: "CourseGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_ParentId",
                table: "CourseGroup",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseGroup");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsDeleted", "RoleTitle" },
                values: new object[] { 1, false, "مدیر سایت" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsDeleted", "RoleTitle" },
                values: new object[] { 2, false, "استاد" });
        }
    }
}
