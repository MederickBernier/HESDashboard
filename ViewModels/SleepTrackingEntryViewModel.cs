namespace HESDashboard.ViewModels;

public class SleepTrackingEntryViewModel {
    public int Id { get; set; }
    public DateOnly? Date { get; set; }

    // Combined time for UI display
    public int? TotalTimeInBedMinutes { get; set; }
    public int? ActualSleepMinutes { get; set; }

    // Optional extras for later views
    public double? PercentAwake { get; set; }
    public double? PercentREM { get; set; }
    public double? PercentLight { get; set; }
    public double? PercentDeep { get; set; }
}
