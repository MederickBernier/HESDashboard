using HESDashboard.Models;

namespace HESDashboard.Services;

public interface IWeeklyReportService {
    Task<List<WeeklyReportDTO>> GenerateWeeklyReportsAsync();
}
