using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeColorAndSizeOptionalForProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_Branches_BranchId",
                table: "BranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProducts_ProductVariants_ProductVariantId",
                table: "BranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductModelId_ColorId_SizeId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchProducts",
                table: "BranchProducts");

            migrationBuilder.RenameTable(
                name: "BranchProducts",
                newName: "BranchProductVariants");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProducts_ProductVariantId",
                table: "BranchProductVariants",
                newName: "IX_BranchProductVariants_ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProducts_BranchId_ProductVariantId",
                table: "BranchProductVariants",
                newName: "IX_BranchProductVariants_BranchId_ProductVariantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeId",
                table: "ProductVariants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorId",
                table: "ProductVariants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchProductVariants",
                table: "BranchProductVariants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductModelId_ColorId_SizeId",
                table: "ProductVariants",
                columns: new[] { "ProductModelId", "ColorId", "SizeId" },
                unique: true,
                filter: "[ColorId] IS NOT NULL AND [SizeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProductVariants_Branches_BranchId",
                table: "BranchProductVariants",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProductVariants_ProductVariants_ProductVariantId",
                table: "BranchProductVariants",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProductVariants_Branches_BranchId",
                table: "BranchProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProductVariants_ProductVariants_ProductVariantId",
                table: "BranchProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductModelId_ColorId_SizeId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchProductVariants",
                table: "BranchProductVariants");

            migrationBuilder.RenameTable(
                name: "BranchProductVariants",
                newName: "BranchProducts");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProductVariants_ProductVariantId",
                table: "BranchProducts",
                newName: "IX_BranchProducts_ProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProductVariants_BranchId_ProductVariantId",
                table: "BranchProducts",
                newName: "IX_BranchProducts_BranchId_ProductVariantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeId",
                table: "ProductVariants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorId",
                table: "ProductVariants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchProducts",
                table: "BranchProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductModelId_ColorId_SizeId",
                table: "ProductVariants",
                columns: new[] { "ProductModelId", "ColorId", "SizeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_Branches_BranchId",
                table: "BranchProducts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProducts_ProductVariants_ProductVariantId",
                table: "BranchProducts",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
