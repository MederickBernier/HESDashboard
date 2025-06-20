using HESDashboard.Models;

namespace HESDashboard.Services;

public interface IHesThresholdService {
    Task<List<HesThreshold>> GetAllAsync();
    Task<HesThreshold?> GetByIdAsync(int id);
    Task AddAsync(HesThreshold hesThreshold);
    Task UpdateAsync(HesThreshold hesThreshold);
    Task DeleteAsync(int id);
}
