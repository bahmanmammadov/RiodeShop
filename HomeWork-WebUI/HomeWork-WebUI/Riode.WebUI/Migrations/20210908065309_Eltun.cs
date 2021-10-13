using Microsoft.EntityFrameworkCore.Migrations;

namespace Riodetask.Migrations
{
    public partial class Eltun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "Sizes",
                newName: "DeleteByUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "ProductImages",
                newName: "DeleteByUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "ProductColors",
                newName: "DeleteByUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "Categories",
                newName: "DeleteByUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "Brands",
                newName: "DeleteByUserId");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                table: "Product",
                newName: "DeleteByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_ProductID",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "Sizes",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "ProductImages",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "ProductColors",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "Categories",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "Brands",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "DeleteByUserId",
                table: "Products",
                newName: "DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
