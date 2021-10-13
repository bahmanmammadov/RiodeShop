using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Riodetask.Migrations
{
    public partial class baseentity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Categories_ParentID",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Sizes_SizeID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ParentID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeID",
                table: "Sizes");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "Sizes",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Sizes",
                newName: "CreatedByUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sizes");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "Sizes",
                newName: "SizeID");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Sizes",
                newName: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ParentID",
                table: "Sizes",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeID",
                table: "Sizes",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Categories_ParentID",
                table: "Sizes",
                column: "ParentID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Sizes_SizeID",
                table: "Sizes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
