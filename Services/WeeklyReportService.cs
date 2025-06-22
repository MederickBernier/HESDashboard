using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HESDashboard.Services;

public class WeeklyReportService : IWeeklyReportService {
    private readonly HesDbContext _context;

    public WeeklyReportService(HesDbContext context) => _context = context;
    public async Task<List<WeeklyReportDTO>> GenerateWeeklyReportsAsync() {
        var allMetrics = await _context.DailyMetrics
            .Where(dm => dm.Date.HasValue)
            .OrderBy(dm => dm.Date)
            .ToListAsync();

        var groupedByWeek = allMetrics
            .GroupBy(dm => ISOWeek.GetWeekOfYear(dm.Date.Value.ToDateTime(TimeOnly.MinValue)))
            .OrderBy(g => g.Key)
            .ToList();

        var reportList = new List<WeeklyReportDTO>();

        double? lastWeekWeightAvg = null;

        foreach (var group in groupedByWeek) {
            var weekMetrics = group.ToList();

            var startDate = weekMetrics.First().Date!.Value;
            var endDate = weekMetrics.Last().Date!.Value;

            var avgWeight = weekMetrics.Average(m => m.WeightLbs);
            var avgHeartRate = weekMetrics.Average(m => m.HeartRate);
            var avgBodyFat = weekMetrics.Average(m => m.BodyFatPercent);
            var avgMuscleMass = weekMetrics.Average(m => m.MuscleMassLbs);
            var avgBMI = weekMetrics.Average(m => m.BMI);
            var avgWater = weekMetrics.Average(m => m.WaterPercent);

            double? delta = (lastWeekWeightAvg.HasValue && avgWeight.HasValue)
                ? avgWeight.Value - lastWeekWeightAvg.Value
                : (double?)null;

            reportList.Add(new WeeklyReportDTO {
                WeekNumber = group.Key,
                StartDate = startDate,
                EndDate = endDate,
                AvgWeight = avgWeight,
                AvgHeartRate = avgHeartRate,
                AvgBodyFatPercent = avgBodyFat,
                AvgMuscleMassLbs = avgMuscleMass,
                AvgBMI = avgBMI,
                AvgWaterPercent = avgWater,
                WeightDelta = delta
            });

            lastWeekWeightAvg = avgWeight;
        }

        return reportList;
    }
}
