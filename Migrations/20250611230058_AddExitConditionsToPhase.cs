using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddExitConditionsToPhase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HesPhaseExitConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesPhaseId = table.Column<int>(type: "int", nullable: false),
                    ConditionDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ConditionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConditionValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesPhaseExitConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HesPhaseExitConditions_HesPhases_HesPhaseId",
                        column: x => x.HesPhaseId,
                        principalTable: "HesPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HesPhaseExitConditions_HesPhaseId",
                table: "HesPhaseExitConditions",
                column: "HesPhaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesPhaseExitConditions");
        }
    }
}
