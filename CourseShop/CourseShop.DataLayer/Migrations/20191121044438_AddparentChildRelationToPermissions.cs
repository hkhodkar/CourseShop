using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseShop.DataLayer.Migrations
{
    public partial class AddparentChildRelationToPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParrentId",
                table: "Permissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParrentId",
                table: "Permissions",
                column: "ParrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParrentId",
                table: "Permissions",
                column: "ParrentId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParrentId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParrentId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ParrentId",
                table: "Permissions");
        }
    }
}
