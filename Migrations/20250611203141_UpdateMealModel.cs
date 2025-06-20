using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mood",
                table: "Meals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanRef",
                table: "Meals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SatietyAfter",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SatietyBefore",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Substitutions",
                table: "Meals",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mood",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "PlanRef",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "SatietyAfter",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "SatietyBefore",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Substitutions",
                table: "Meals");
        }
    }
}
