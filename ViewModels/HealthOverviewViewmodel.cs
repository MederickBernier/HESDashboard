using HESDashboard.Models;

namespace HESDashboard.ViewModels;

public class HealthOverviewViewModel {
    public DailyMetric? Latest { get; set; }
    public DailyMetric? Previous { get; set; }
    public DailyMetric? First { get; set; }

    // Short-Term (latest vs previous)
    public double DeltaWeight { get; set; }
    public double DeltaBMI { get; set; }
    public double DeltaBodyFat { get; set; }
    public int DeltaHeartRate { get; set; }

    // Long-Term (latest vs first)
    public double TrendWeight { get; set; }
    public double TrendBMI { get; set; }
    public double TrendBodyFat { get; set; }
    public int TrendHeartRate { get; set; }

    // 📊 For trend charts
    public List<DailyMetric> Metrics { get; set; } = new();
    public List<ForecastResultDTO>? Forecasts { get; set; }

    public List<Meal>? TodaysMeals { get; set; }

    public int TotalCaloriesToday => TodaysMeals?.Sum(m => m.Calories ?? 0) ?? 0;
    public List<Training> TodaysTrainings { get; set; } = new();
    public int? TotalTrainingDurationToday => TodaysTrainings?.Sum(t => t.DurationSeconds) ?? 0;
    public double? TotalTrainingDistanceToday => TodaysTrainings?.Sum(t => t.DistanceKm ?? 0);
    public int? TotalCaloriesBurnedToday => TodaysTrainings?.Sum(t => t.Calories ?? 0);

    public List<HesPhase> AllPhases { get; set; } = new();

    public HesPhase? CurrentPhase => AllPhases
        .Where(p => p.IsActive)
        .OrderBy(p => p.Order)
        .FirstOrDefault();

    public List<HesGoal> CurrentPhaseUnmetGoals => CurrentPhase?.Goals
        .Where(g => g.IsActive /* && !g.IsCompleted */) // You can refine this logic later
        .ToList() ?? new();

    public TimeSpan? TimeSinceLastMeal { get; set; }
    public bool MealDriftWarning { get; set; }
    public string? MealDriftMessage { get; set; }

}
