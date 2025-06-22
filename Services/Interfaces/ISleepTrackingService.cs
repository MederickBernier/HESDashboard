using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface ISleepTrackingService {
    Task<List<SleepTrackingEntry>> GetAllAsync();
    Task<SleepTrackingEntry?> GetByIdAsync(int id);
    Task AddAsync(SleepTrackingEntry entry);
    Task UpdateAsync(SleepTrackingEntry entry);
    Task DeleteAsync(int id);
}
