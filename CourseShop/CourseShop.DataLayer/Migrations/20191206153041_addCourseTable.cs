using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class addCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(maxLength: 200, nullable: false),
                    SubGroupId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseStatusId = table.Column<int>(nullable: false),
                    CourseLevelId = table.Column<int>(nullable: false),
                    CourseTitle = table.Column<string>(maxLength: 200, nullable: false),
                    CourseDescription = table.Column<string>(nullable: false),
                    CoursePrice = table.Column<int>(maxLength: 50, nullable: false),
                    Tags = table.Column<string>(maxLength: 600, nullable: true),
                    ImageName = table.Column<string>(maxLength: 50, nullable: true),
                    DemoFileName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_CourseLevel_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevel",
                        principalColumn: "CourseLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseStatus_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "CourseStatus",
                        principalColumn: "CourseStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "CourseGroup",
                        principalColumn: "CourseGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseGroup_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "CourseGroup",
                        principalColumn: "CourseGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEpisode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    EpisodeTitle = table.Column<string>(maxLength: 200, nullable: false),
                    EpisodeTiem = table.Column<TimeSpan>(nullable: false),
                    EpisodeFileName = table.Column<string>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEpisode", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_CourseEpisode_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseLevelId",
                table: "Course",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseStatusId",
                table: "Course",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_GroupId",
                table: "Course",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubGroupId",
                table: "Course",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEpisode_CourseId",
                table: "CourseEpisode",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEpisode");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
