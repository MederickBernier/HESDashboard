using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerceivedExertion",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingType",
                table: "Training",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "WeightKg",
                table: "Training",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerceivedExertion",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "WeightKg",
                table: "Training");
        }
    }
}
