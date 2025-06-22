using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface IHealthService {
    Task<List<DailyMetric>> GetAllAsync(int page, int pageSize);
    Task<DailyMetric?> GetByIdAsync(int id);
    Task AddAsync(DailyMetric metric);
    Task UpdateAsync(DailyMetric metric);
    Task DeleteAsync(int id);

    Task<double> GetAverageWeightAsync();
    Task<(double start, double end, double delta)> GetWeightDeltaAsync();
    Task<DailyMetric?> GetLatestAsync();
    Task<DailyMetric?> GetEarliestAsync();
    Task<int> GetCountAsync();
    Task<List<DailyMetric>> GetEverythingAsync();
    Task<List<HesPhase>> GetAllPhasesAsync();
    Task<HesPhase?> GetCurrentPhaseAsync();

}
