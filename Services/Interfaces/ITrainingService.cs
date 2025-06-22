using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface ITrainingService {
    Task<List<Training>> GetAllAsync();
    Task<Training?> GetByIdAsync(int id);
    Task AddAsync(Training training);
    Task UpdateAsync(Training training);
    Task DeleteAsync(int id);
}
