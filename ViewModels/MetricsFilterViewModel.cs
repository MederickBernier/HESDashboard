using HESDashboard.Models;

namespace HESDashboard.ViewModels;

public class MetricsFilterViewModel {
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? SortBy { get; set; }
    public List<DailyMetric> Results { get; set; } = new();

    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public int TotalPages { get; set; }
}
