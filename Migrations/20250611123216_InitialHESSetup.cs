using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class InitialHESSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    WeightLbs = table.Column<double>(type: "float", nullable: true),
                    BMI = table.Column<double>(type: "float", nullable: true),
                    BodyFatPercent = table.Column<double>(type: "float", nullable: true),
                    HeartRate = table.Column<int>(type: "int", nullable: true),
                    MuscleMassLbs = table.Column<double>(type: "float", nullable: true),
                    BMRKcal = table.Column<int>(type: "int", nullable: true),
                    WaterPercent = table.Column<double>(type: "float", nullable: true),
                    BodyFatMassLbs = table.Column<double>(type: "float", nullable: true),
                    LeanBodyMassLbs = table.Column<double>(type: "float", nullable: true),
                    BoneMassLbs = table.Column<double>(type: "float", nullable: true),
                    VisceralFat = table.Column<int>(type: "int", nullable: true),
                    ProteinPercent = table.Column<double>(type: "float", nullable: true),
                    SkeletalMuscleMassLbs = table.Column<double>(type: "float", nullable: true),
                    SubcutaneousFatPercent = table.Column<double>(type: "float", nullable: true),
                    BodyAgeYears = table.Column<int>(type: "int", nullable: true),
                    BodyType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MealType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    ProteinGrams = table.Column<double>(type: "float", nullable: true),
                    CarbsGrams = table.Column<double>(type: "float", nullable: true),
                    FatGrams = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Timeframe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DurationMinutes = table.Column<TimeOnly>(type: "time", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Steps = table.Column<int>(type: "int", nullable: true),
                    AvgSpeedKmh = table.Column<double>(type: "float", nullable: true),
                    MaxSpeedKmh = table.Column<double>(type: "float", nullable: true),
                    AvgPace = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaxPace = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ElevationMinM = table.Column<int>(type: "int", nullable: true),
                    ElevationMaxM = table.Column<int>(type: "int", nullable: true),
                    TotalAscentKm = table.Column<double>(type: "float", nullable: true),
                    HeartRateAvg = table.Column<int>(type: "int", nullable: true),
                    HeartRateMax = table.Column<int>(type: "int", nullable: true),
                    CadenceAvg = table.Column<int>(type: "int", nullable: true),
                    CadenceMax = table.Column<int>(type: "int", nullable: true),
                    TemperatureC = table.Column<int>(type: "int", nullable: true),
                    Weather = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    WaterMl = table.Column<int>(type: "int", nullable: true),
                    PainScore = table.Column<int>(type: "int", nullable: true),
                    MoodAfter = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMetrics");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
