using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface IWeeklyReportService {
    Task<List<WeeklyReportDTO>> GenerateWeeklyReportsAsync();
}
