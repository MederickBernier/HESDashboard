using System;
using System.ComponentModel.DataAnnotations;

namespace HESDashboard.ViewModels {
    public class SleepTrackingEntryFormViewModel {
        public int? Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateOnly? Date { get; set; }

        [Display(Name = "Start of Sleep")]
        [DataType(DataType.DateTime)]
        public DateTime? StartOfSleep { get; set; }

        [Display(Name = "End of Sleep")]
        [DataType(DataType.DateTime)]
        public DateTime? EndOfSleep { get; set; }

        // Total time in bed
        [Display(Name = "Total Time in Bed (Hours)")]
        public int? TotalTimeInBed_Hours { get; set; }

        [Display(Name = "Total Time in Bed (Minutes)")]
        public int? TotalTimeInBed_Minutes { get; set; }

        // Actual sleep time
        [Display(Name = "Actual Sleep Time (Hours)")]
        public int? ActualSleep_Hours { get; set; }

        [Display(Name = "Actual Sleep Time (Minutes)")]
        public int? ActualSleep_Minutes { get; set; }

        // Awake time
        [Display(Name = "Percent Awake (%)")]
        public double? PercentAwake { get; set; }

        [Display(Name = "Time Awake (Hours)")]
        public int? TimeAwake_Hours { get; set; }

        [Display(Name = "Time Awake (Minutes)")]
        public int? TimeAwake_Minutes { get; set; }

        // REM Sleep
        [Display(Name = "Percent REM Sleep (%)")]
        public double? PercentREM { get; set; }

        [Display(Name = "Time REM Sleep (Hours)")]
        public int? TimeREM_Hours { get; set; }

        [Display(Name = "Time REM Sleep (Minutes)")]
        public int? TimeREM_Minutes { get; set; }

        // Light Sleep
        [Display(Name = "Percent Light Sleep (%)")]
        public double? PercentLight { get; set; }

        [Display(Name = "Time Light Sleep (Hours)")]
        public int? TimeLight_Hours { get; set; }

        [Display(Name = "Time Light Sleep (Minutes)")]
        public int? TimeLight_Minutes { get; set; }

        // Deep Sleep
        [Display(Name = "Percent Deep Sleep (%)")]
        public double? PercentDeep { get; set; }

        [Display(Name = "Time Deep Sleep (Hours)")]
        public int? TimeDeep_Hours { get; set; }

        [Display(Name = "Time Deep Sleep (Minutes)")]
        public int? TimeDeep_Minutes { get; set; }

        // Additional health metrics
        [Display(Name = "Lowest Blood Oxygen (%)")]
        public double? LowestBloodOxygen { get; set; }

        [Display(Name = "Highest Skin Temperature (°C)")]
        public double? HighestSkinTemp { get; set; }

        [Display(Name = "Lowest Skin Temperature (°C)")]
        public double? LowestSkinTemp { get; set; }

        [Display(Name = "Average Heart Rate (bpm)")]
        public int? AvgHeartRate { get; set; }

        [Display(Name = "Average Respiratory Rate (rpm)")]
        public double? AvgRespiratoryRate { get; set; }
    }
}
