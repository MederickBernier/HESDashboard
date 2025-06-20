using HESDashboard.Data;
using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class HesGoalService : IHesGoalService {
    private readonly HesDbContext _context;

    public HesGoalService(HesDbContext context) {
        _context = context;
    }

    public async Task<List<HesGoal>> GetAllAsync(int? phaseId = null) {
        var query = _context.HesGoals.Include(g => g.Phase).AsQueryable();
        if (phaseId.HasValue)
            query = query.Where(g => g.HesPhaseId == phaseId.Value);
        return await query.ToListAsync();
    }

    public async Task<HesGoal?> GetByIdAsync(int id) =>
        await _context.HesGoals.Include(g => g.Phase).FirstOrDefaultAsync(g => g.Id == id);

    public async Task AddAsync(HesGoal goal) {
        _context.HesGoals.Add(goal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HesGoal goal) {
        _context.HesGoals.Update(goal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var goal = await _context.HesGoals.FindAsync(id);
        if (goal != null) {
            _context.HesGoals.Remove(goal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<HesPhase>> GetAllPhasesAsync() =>
        await _context.HesPhases.OrderBy(p => p.Order).ToListAsync();
}
