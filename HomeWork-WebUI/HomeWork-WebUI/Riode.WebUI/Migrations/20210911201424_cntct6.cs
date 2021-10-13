using Microsoft.EntityFrameworkCore.Migrations;

namespace Riodetask.Migrations
{
    public partial class cntct6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPosts",
                table: "ContactPosts");

            migrationBuilder.RenameTable(
                name: "ContactPosts",
                newName: "Contacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContactPosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPosts",
                table: "ContactPosts",
                column: "ID");
        }
    }
}
