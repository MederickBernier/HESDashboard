using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddBiometricFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BloodSugarMgDl",
                table: "DailyMetrics",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BodyTemperatureC",
                table: "DailyMetrics",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiastolocBP",
                table: "DailyMetrics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PulseRate",
                table: "DailyMetrics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RestingOxygenPercent",
                table: "DailyMetrics",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystolicBP",
                table: "DailyMetrics",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodSugarMgDl",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "BodyTemperatureC",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "DiastolocBP",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "PulseRate",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "RestingOxygenPercent",
                table: "DailyMetrics");

            migrationBuilder.DropColumn(
                name: "SystolicBP",
                table: "DailyMetrics");
        }
    }
}
