namespace HESDashboard.DTOs;

public class SleepTrackingExportDTO {
    public DateOnly? Date { get; set; }
    public DateTime? StartOfSleep { get; set; }
    public DateTime? EndOfSleep { get; set; }

    public double? TotalTimeInBedMinutes { get; set; }
    public double? ActualSleepMinutes { get; set; }
    public double? TimeAwakeMinutes { get; set; }

    public double? TimeREM_Minutes { get; set; }
    public double? TimeLight_Minutes { get; set; }
    public double? TimeDeep_Minutes { get; set; }

    public double? PercentAwake { get; set; }
    public double? PercentREM { get; set; }
    public double? PercentLight { get; set; }
    public double? PercentDeep { get; set; }

    public double? LowestBloodOxygen { get; set; }
    public double? HighestSkinTemp { get; set; }
    public double? LowestSkinTemp { get; set; }

    public int? AvgHeartRate { get; set; }
    public double? AvgRespiratoryRate { get; set; }

}
