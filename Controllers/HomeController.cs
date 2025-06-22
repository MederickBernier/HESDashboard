using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using HESDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Controllers;

public class HomeController : Controller {
    private readonly HesDbContext _context;
    private readonly IForecastService _forecastService;

    public HomeController(HesDbContext context, IForecastService forecastService) {
        _context = context;
        _forecastService = forecastService;
    }

    public async Task<IActionResult> Index() {

        var metrics = await _context.DailyMetrics
            .OrderBy(d => d.Date)
            .ToListAsync();

        var first = metrics.FirstOrDefault();
        var latest = metrics.LastOrDefault();
        var previous = metrics.Count > 1 ? metrics[^2] : null;

        //var forecasts = await _forecastService.GenerateForecastAsync();
        var today = DateOnly.FromDateTime(DateTime.Today);

        var todaysMeals = await _context.Meals
            .Where(m => m.Date == today)
            .OrderBy(m => m.MealType)
            .ToListAsync();

        var todaysTrainings = await _context.Trainings
            .Where(t => t.Date == today)
            .OrderBy(t => t.Timeframe)
            .ToListAsync();

        var allPhases = await _context.HesPhases
            .Include(p => p.Goals)
            .Where(p => p.IsActive)
            .OrderBy(p => p.Order)
            .ToListAsync();

        var lastMealToday = todaysMeals
            .OrderByDescending(m => m.TimeLogged)
            .FirstOrDefault();

        TimeSpan? timeSinceLastMeal = lastMealToday != null
            ? DateTime.Now - lastMealToday.TimeLogged
            : null;

        bool driftWarning = timeSinceLastMeal?.TotalHours >= 5;
        string? driftMessage = timeSinceLastMeal != null
            ? $"Last meal was {timeSinceLastMeal.Value.Hours:D2}h {timeSinceLastMeal.Value.Minutes:D2}m ago."
            : "No meals logged today.";

        var model = new HealthOverviewViewModel {
            First = first,
            Latest = latest,
            Previous = previous,
            Metrics = metrics,
            //Forecasts = forecasts,
            TodaysMeals = todaysMeals,
            TodaysTrainings = todaysTrainings,
            AllPhases = allPhases,

            DeltaWeight = (latest?.WeightLbs ?? 0) - (previous?.WeightLbs ?? 0),
            DeltaBMI = (latest?.BMI ?? 0) - (previous?.BMI ?? 0),
            DeltaBodyFat = (latest?.BodyFatPercent ?? 0) - (previous?.BodyFatPercent ?? 0),
            DeltaHeartRate = (latest?.HeartRate ?? 0) - (previous?.HeartRate ?? 0),

            TrendWeight = (latest?.WeightLbs ?? 0) - (first?.WeightLbs ?? 0),
            TrendBMI = (latest?.BMI ?? 0) - (first?.BMI ?? 0),
            TrendBodyFat = (latest?.BodyFatPercent ?? 0) - (first?.BodyFatPercent ?? 0),
            TrendHeartRate = (latest?.HeartRate ?? 0) - (first?.HeartRate ?? 0),
            TimeSinceLastMeal = timeSinceLastMeal,
            MealDriftWarning = driftWarning,
            MealDriftMessage = driftMessage,
        };

        return View(model);
    }

    public IActionResult Privacy() => View();
}
