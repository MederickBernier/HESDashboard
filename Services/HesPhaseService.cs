using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class HesPhaseService : IHesPhaseService {
    private readonly HesDbContext _context;

    public HesPhaseService(HesDbContext context) {
        _context = context;
    }

    public async Task<List<HesPhase>> GetAllAsync() =>
        await _context.HesPhases.OrderBy(p => p.Order).ToListAsync();

    public async Task<HesPhase?> GetByIdAsync(int id) {
        return await _context.HesPhases
            .Include(p => p.ExitConditions)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(HesPhase phase) {
        _context.HesPhases.Add(phase);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HesPhase phase) {
        _context.HesPhases.Update(phase);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var phase = await _context.HesPhases.FindAsync(id);
        if (phase != null) {
            _context.HesPhases.Remove(phase);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<HesPhaseExitCondition>> GetExitConditionsAsync(int phaseId) {
        return _context.HesPhaseExitConditions
            .Where(e => e.HesPhaseId == phaseId)
            .ToListAsync();
    }

    public async Task AddExitConditionAsync(HesPhaseExitCondition condition) {
        _context.HesPhaseExitConditions.Add(condition);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExitConditionAsync(HesPhaseExitCondition condition) {
        _context.HesPhaseExitConditions.Update(condition);
        await _context.SaveChangesAsync();
    }

    public async Task ToggleConditionMetAsync(int conditionId) {
        var condition = await _context.HesPhaseExitConditions
        .Include(c => c.Phase)
        .FirstOrDefaultAsync(c => c.Id == conditionId);

        if (condition != null) {
            condition.IsMet = !condition.IsMet;

            await _context.SaveChangesAsync();

            var allConditionsMet = await _context.HesPhaseExitConditions
                .Where(c => c.HesPhaseId == condition.HesPhaseId && c.IsRequired)
                .AllAsync(c => c.IsMet);

            if (allConditionsMet && !condition.Phase.IsCompleted) {
                condition.Phase.IsCompleted = true;
                _context.HesPhases.Update(condition.Phase);
                await _context.SaveChangesAsync();
            }
        }
    }
    public async Task UpdatePhaseWithExitConditionsAsync(HesPhase updatedPhase) {
        var existingPhase = await _context.HesPhases
            .Include(p => p.ExitConditions)
            .FirstOrDefaultAsync(p => p.Id == updatedPhase.Id);

        if (existingPhase == null)
            throw new Exception("Phase not found.");

        // Update base fields
        _context.Entry(existingPhase).CurrentValues.SetValues(updatedPhase);

        // Sync exit conditions
        existingPhase.ExitConditions.Clear();
        foreach (var cond in updatedPhase.ExitConditions) {
            cond.Id = 0; // Reset to ensure EF re-creates or assigns appropriately
            existingPhase.ExitConditions.Add(cond);
        }

        await _context.SaveChangesAsync();
    }

}
