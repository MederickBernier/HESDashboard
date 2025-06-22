using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HESDashboard.Models;

public class SleepTrackingEntry {
    public int Id { get; set; }

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateOnly? Date { get; set; }

    [Display(Name = "Start of Sleep")]
    public DateTime? StartOfSleep { get; set; }

    [Display(Name = "End of Sleep")]
    public DateTime? EndOfSleep { get; set; }

    [Display(Name = "Total Time in Bed")]
    public TimeSpan? TotalTimeInBed { get; set; }

    [Display(Name = "Actual Sleep Time")]
    public TimeSpan? ActualSleepTime { get; set; }

    [Display(Name = "Percent Awake (%)")]
    public double? PercentAwake { get; set; }

    [Display(Name = "Time Awake")]
    public TimeSpan? TimeAwake { get; set; }

    [Display(Name = "Percent REM Sleep (%)")]
    public double? PercentREM { get; set; }

    [Display(Name = "Time REM Sleep")]
    public TimeSpan? TimeREM { get; set; }

    [Display(Name = "Percent Light Sleep (%)")]
    public double? PercentLight { get; set; }

    [Display(Name = "Time Light Sleep")]
    public TimeSpan? TimeLight { get; set; }

    [Display(Name = "Percent Deep Sleep (%)")]
    public double? PercentDeep { get; set; }

    [Display(Name = "Time Deep Sleep")]
    public TimeSpan? TimeDeep { get; set; }

    [Display(Name = "Lowest Blood Oxygen (%)")]
    public double? LowestBloodOxygen { get; set; }

    [Display(Name = "Highest Skin Temperature (°C)")]
    public double? HighestSkinTemp { get; set; }

    [Display(Name = "Lowest Skin Temperature (°C)")]
    public double? LowestSkinTemp { get; set; }

    [Display(Name = "Avg Heart Rate (bpm)")]
    public int? AvgHeartRate { get; set; }

    [Display(Name = "Avg Respiratory Rate (rpm)")]
    public double? AvgRespiratoryRate { get; set; }
}
