using HESDashboard.Data;
using HESDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HESDashboard.Controllers;
public class MetricsController : Controller {
    private readonly HesDbContext _context;

    public MetricsController(HesDbContext context) {
        _context = context;
    }

    public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, string? sortBy, int page = 1) {
        int pageSize = 20;

        var query = _context.DailyMetrics.AsQueryable();

        DateOnly? start = startDate.HasValue ? DateOnly.FromDateTime(startDate.Value) : null;
        DateOnly? end = endDate.HasValue ? DateOnly.FromDateTime(endDate.Value) : null;

        if (start.HasValue)
            query = query.Where(m => m.Date >= start.Value);
        if (end.HasValue)
            query = query.Where(m => m.Date <= end.Value);

        query = sortBy switch {
            "weight" => query.OrderByDescending(m => m.WeightLbs),
            "bmi" => query.OrderByDescending(m => m.BMI),
            "bodyfat" => query.OrderByDescending(m => m.BodyFatPercent),
            "heartrate" => query.OrderByDescending(m => m.HeartRate),
            _ => query.OrderByDescending(m => m.Date)
        };

        int totalCount = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var results = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var model = new MetricsFilterViewModel {
            StartDate = startDate,
            EndDate = endDate,
            SortBy = sortBy,
            Results = results,
            CurrentPage = page,
            TotalPages = totalPages
        };

        return View(model);
    }

    public async Task<IActionResult> ExportCsv(DateTime? startDate, DateTime? endDate) {
        var query = _context.DailyMetrics.AsQueryable();

        if (startDate.HasValue)
            query = query.Where(m => m.Date >= DateOnly.FromDateTime(startDate.Value));
        if (endDate.HasValue)
            query = query.Where(m => m.Date <= DateOnly.FromDateTime(endDate.Value));

        var data = await query.OrderBy(m => m.Date).ToListAsync();

        var sb = new StringBuilder();
        sb.AppendLine("Date,WeightLbs,BMI,BodyFatPercent,HeartRate");

        foreach (var m in data) {
            sb.AppendLine($"{m.Date:yyyy-MM-dd},{m.WeightLbs},{m.BMI},{m.BodyFatPercent},{m.HeartRate}");
        }

        var bytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(bytes, "text/csv", $"metrics_{DateTime.Now:yyyyMMdd}.csv");
    }

    public async Task<IActionResult> ExportJson(DateTime? startDate, DateTime? endDate) {
        var query = _context.DailyMetrics.AsQueryable();

        if (startDate.HasValue)
            query = query.Where(m => m.Date >= DateOnly.FromDateTime(startDate.Value));
        if (endDate.HasValue)
            query = query.Where(m => m.Date <= DateOnly.FromDateTime(endDate.Value));

        var data = await query.OrderBy(m => m.Date).ToListAsync();
        return Json(data);
    }
}
