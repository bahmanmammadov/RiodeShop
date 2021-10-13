using Microsoft.EntityFrameworkCore.Migrations;

namespace Riodetask.Migrations
{
    public partial class Sizechild1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Sizes");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ParentID",
                table: "Sizes",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Categories_ParentID",
                table: "Sizes",
                column: "ParentID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Categories_ParentID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ParentID",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
