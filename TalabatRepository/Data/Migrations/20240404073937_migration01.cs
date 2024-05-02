using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Repository.Data.Migrations
{
    public partial class migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductBrand_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductType_ProductTypeId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrand",
                table: "ProductBrand");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "productsType");

            migrationBuilder.RenameTable(
                name: "ProductBrand",
                newName: "productBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsType",
                table: "productsType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productsType_ProductTypeId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsType",
                table: "productsType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productBrands",
                table: "productBrands");

            migrationBuilder.RenameTable(
                name: "productsType",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "productBrands",
                newName: "ProductBrand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrand",
                table: "ProductBrand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductBrand_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "ProductBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductType_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
