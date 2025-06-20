using HESDashboard.Data;
using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class ForecastService : IForecastService {
    private readonly HesDbContext _db;

    public ForecastService(HesDbContext db) => _db = db;

    public async Task<List<ForecastResultDTO>> GenerateForecastAsync() {
        var data = await _db.DailyMetrics
            .OrderBy(m => m.Date)
            .ToListAsync();

        var results = new List<ForecastResultDTO>();

        // Ensure MetricName strings match what's expected in the view
        AddForecast(results, data, "WeightLbs", m => m.WeightLbs, "lbs");
        AddForecast(results, data, "BMI", m => m.BMI, "");
        AddForecast(results, data, "BodyFatPercent", m => m.BodyFatPercent, "%");
        AddForecast(results, data, "HeartRate", m => m.HeartRate.HasValue ? (double?)m.HeartRate : null, "bpm");

        return results;
    }

    private void AddForecast(
        List<ForecastResultDTO> results,
        List<DailyMetric> data,
        string metricName,
        Func<DailyMetric, double?> selector,
        string unit
    ) {
        var values = data.Select(selector).Where(v => v.HasValue).Select(v => v.Value).ToList();
        if (values.Count < 2) return;

        var current = values.Last();
        var slope = (values.Last() - values.First()) / values.Count;

        results.Add(new ForecastResultDTO {
            MetricName = metricName,
            CurrentValue = current,
            Forecast7Days = current + slope * 7,
            Forecast14Days = current + slope * 14,
            Forecast30Days = current + slope * 30,
            AlgorithmUsed = "SMA"
        });
    }
}
