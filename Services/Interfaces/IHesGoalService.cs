using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface IHesGoalService {
    Task<List<HesGoal>> GetAllAsync(int? phaseId = null);
    Task<HesGoal?> GetByIdAsync(int id);
    Task AddAsync(HesGoal goal);
    Task UpdateAsync(HesGoal goal);
    Task DeleteAsync(int id);
    Task<List<HesPhase>> GetAllPhasesAsync();
}
