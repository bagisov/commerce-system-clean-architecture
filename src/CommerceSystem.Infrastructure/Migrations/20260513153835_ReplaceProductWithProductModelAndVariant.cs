using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceProductWithProductModelAndVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Products_ProductId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BranchId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Stocks",
                newName: "ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                newName: "IX_Stocks_ProductVariantId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "BranchProducts",
                newName: "ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProducts_ProductId",
                table: "BranchProducts",
                newName: "IX_BranchProducts_ProductVariantId");

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModels_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModels_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseSellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BranchId_ProductVariantId",
                table: "Stocks",
                columns: new[] { "BranchId", "ProductVariantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId_ProductVariantId",
                table: "BranchProducts",
                columns: new[] { "BranchId", "ProductVariantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_BrandId_CategoryId_Name",
                table: "ProductModels",
                columns: new[] { "BrandId", "CategoryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_CategoryId",
                table: "ProductModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductModelId_ColorId_SizeId",
                table: "ProductVariants",
                columns: new[] { "ProductModelId", "ColorId", "SizeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_ProductVariants_ProductVariantId",
                table: "BranchProducts",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ProductVariants_ProductVariantId",
                table: "Stocks",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_ProductVariants_ProductVariantId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ProductVariants_ProductVariantId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BranchId_ProductVariantId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_BranchProducts_BranchId_ProductVariantId",
                table: "BranchProducts");

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "Stocks",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductVariantId",
                table: "Stocks",
                newName: "IX_Stocks_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "BranchProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProducts_ProductVariantId",
                table: "BranchProducts",
                newName: "IX_BranchProducts_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseSellingPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BranchId",
                table: "Stocks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Products_ProductId",
                table: "BranchProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
