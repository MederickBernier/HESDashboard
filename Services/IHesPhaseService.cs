using HESDashboard.Models;

namespace HESDashboard.Services;

public interface IHesPhaseService {
    Task<List<HesPhase>> GetAllAsync();
    Task<HesPhase?> GetByIdAsync(int id);
    Task AddAsync(HesPhase phase);
    Task UpdateAsync(HesPhase phase);
    Task DeleteAsync(int id);
    Task<List<HesPhaseExitCondition>> GetExitConditionsAsync(int phaseId);
    Task AddExitConditionAsync(HesPhaseExitCondition condition);
    Task UpdateExitConditionAsync(HesPhaseExitCondition condition);
    Task ToggleConditionMetAsync(int conditionId);
    Task UpdatePhaseWithExitConditionsAsync(HesPhase phase);
}
