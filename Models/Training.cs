using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HESDashboard.Models;
public class Training {
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required, MaxLength(30)]
    public string TrainingType { get; set; } = "Walking"; // NEW

    [Required, MaxLength(20)]
    public string Timeframe { get; set; } = string.Empty;

    [Required]
    public int DurationSeconds { get; set; }

    [NotMapped]
    public TimeSpan Duration {
        get => TimeSpan.FromSeconds(DurationSeconds);
        set => DurationSeconds = (int)value.TotalSeconds;
    }

    public double? DistanceKm { get; set; }
    public int? Calories { get; set; }
    public int? Steps { get; set; }
    public double? AvgSpeedKmh { get; set; }
    public double? MaxSpeedKmh { get; set; }

    [MaxLength(10)]
    public string? AvgPace { get; set; }

    [MaxLength(10)]
    public string? MaxPace { get; set; }

    public int? ElevationMinM { get; set; }
    public int? ElevationMaxM { get; set; }
    public double? TotalAscentKm { get; set; }

    public int? HeartRateAvg { get; set; }
    public int? HeartRateMax { get; set; }

    public int? CadenceAvg { get; set; }
    public int? CadenceMax { get; set; }

    public int? TemperatureC { get; set; }

    [MaxLength(20)]
    public string? Weather { get; set; }

    public int? WaterMl { get; set; }
    public int? PainScore { get; set; }
    public int? MoodAfter { get; set; }

    // NEW - Strength/HIIT Support
    public int? Sets { get; set; }
    public int? Repetitions { get; set; }
    public double? WeightKg { get; set; }

    public int? PerceivedExertion { get; set; } // NEW - 1 to 10 scale

    [MaxLength(1000)]
    public string? Notes { get; set; }
}
