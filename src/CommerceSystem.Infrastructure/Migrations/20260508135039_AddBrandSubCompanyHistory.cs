using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandSubCompanyHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedSubCompanyAtUtc",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BrandSubCompanyHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnteredAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeftAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandSubCompanyHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandSubCompanyHistories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrandSubCompanyHistories_SubCompanies_SubCompanyId",
                        column: x => x.SubCompanyId,
                        principalTable: "SubCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandSubCompanyHistories_BrandId",
                table: "BrandSubCompanyHistories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandSubCompanyHistories_SubCompanyId",
                table: "BrandSubCompanyHistories",
                column: "SubCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandSubCompanyHistories");

            migrationBuilder.DropColumn(
                name: "JoinedSubCompanyAtUtc",
                table: "Brands");
        }
    }
}
