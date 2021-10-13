using Microsoft.EntityFrameworkCore.Migrations;

namespace Riodetask.Migrations
{
    public partial class Sizechild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeID",
                table: "Sizes",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Sizes_SizeID",
                table: "Sizes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Sizes_SizeID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Sizes");
        }
    }
}
