namespace HESDashboard.Models;

public class WeeklyReportDTO {
    public int WeekNumber { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double? AvgWeight { get; set; }
    public double? AvgHeartRate { get; set; }
    public double? WeightDelta { get; set; }
    public double? AvgBodyFatPercent { get; set; }
    public double? AvgMuscleMassLbs { get; set; }
    public double? AvgBMI { get; set; }
    public double? AvgWaterPercent { get; set; }
}
