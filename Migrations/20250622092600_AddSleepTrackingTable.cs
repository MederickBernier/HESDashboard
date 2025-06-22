using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HESDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddSleepTrackingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SleepTrackingEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    StartOfSleep = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndOfSleep = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTimeInBed = table.Column<TimeSpan>(type: "time", nullable: true),
                    ActualSleepTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    PercentAwake = table.Column<double>(type: "float", nullable: true),
                    TimeAwake = table.Column<TimeSpan>(type: "time", nullable: true),
                    PercentREM = table.Column<double>(type: "float", nullable: true),
                    TimeREM = table.Column<TimeSpan>(type: "time", nullable: true),
                    PercentLight = table.Column<double>(type: "float", nullable: true),
                    TimeLight = table.Column<TimeSpan>(type: "time", nullable: true),
                    PercentDeep = table.Column<double>(type: "float", nullable: true),
                    TimeDeep = table.Column<TimeSpan>(type: "time", nullable: true),
                    LowestBloodOxygen = table.Column<double>(type: "float", nullable: true),
                    HighestSkinTemp = table.Column<double>(type: "float", nullable: true),
                    LowestSkinTemp = table.Column<double>(type: "float", nullable: true),
                    AvgHeartRate = table.Column<int>(type: "int", nullable: true),
                    AvgRespiratoryRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepTrackingEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SleepTrackingEntries");
        }
    }
}
