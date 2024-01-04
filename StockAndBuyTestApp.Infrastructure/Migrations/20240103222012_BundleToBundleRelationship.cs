using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAndBuyTestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BundleToBundleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BundleToBundleRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentBundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChildBundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityNeeded = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleToBundleRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleToBundleRelationship_ChildBundle",
                        column: x => x.ChildBundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleToBundleRelationship_ParentBundle",
                        column: x => x.ParentBundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleToBundleRelationships_ChildBundleId",
                table: "BundleToBundleRelationships",
                column: "ChildBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleToBundleRelationships_ParentBundleId",
                table: "BundleToBundleRelationships",
                column: "ParentBundleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleToBundleRelationships");
        }
    }
}
