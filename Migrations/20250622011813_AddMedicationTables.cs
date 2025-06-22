using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultDosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsualWithFood = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationCatalogId = table.Column<int>(type: "int", nullable: false),
                    TimeTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosageOverride = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithFood = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationEntries_MedicationCatalogs_MedicationCatalogId",
                        column: x => x.MedicationCatalogId,
                        principalTable: "MedicationCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationEntries_MedicationCatalogId",
                table: "MedicationEntries",
                column: "MedicationCatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationEntries");

            migrationBuilder.DropTable(
                name: "MedicationCatalogs");
        }
    }
}
