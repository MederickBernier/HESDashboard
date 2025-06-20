using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMoodSatiety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mood",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "Satiety",
                table: "DailyMetrics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "DailyMetrics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Satiety",
                table: "DailyMetrics",
                type: "int",
                nullable: true);
        }
    }
}
