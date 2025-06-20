using HESDashboard.Data;
using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class HealthService : IHealthService {
    private readonly HesDbContext _context;

    public HealthService(HesDbContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task AddAsync(DailyMetric metric) {
        _context.DailyMetrics.Add(metric);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var entry = await GetByIdAsync(id);
        if (entry != null) {
            _context.DailyMetrics.Remove(entry);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<DailyMetric>> GetAllAsync(int page, int pageSize) {
        return await _context.DailyMetrics
        .OrderByDescending(d => d.Date)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    }

    public async Task<List<DailyMetric>> GetEverythingAsync() {
        return await _context.DailyMetrics
            .OrderByDescending(dm => dm.Date)
            .ToListAsync();
    }

    public async Task<int> GetCountAsync() {
        return await _context.DailyMetrics.CountAsync();
    }


    public async Task<double> GetAverageWeightAsync() {
        return await _context.DailyMetrics.AverageAsync(dm => dm.WeightLbs ?? 0.0);
    }

    public async Task<DailyMetric?> GetByIdAsync(int id) {
        return await _context.DailyMetrics.FindAsync(id);
    }

    public async Task<DailyMetric?> GetEarliestAsync() {
        return await _context.DailyMetrics.OrderBy(dm => dm.Date).FirstOrDefaultAsync();
    }

    public async Task<DailyMetric?> GetLatestAsync() {
        return await _context.DailyMetrics.OrderByDescending(dm => dm.Date).FirstOrDefaultAsync();
    }

    public async Task<(double start, double end, double delta)> GetWeightDeltaAsync() {
        var first = await _context.DailyMetrics.OrderBy(dm => dm.Date).FirstOrDefaultAsync();
        var last = await _context.DailyMetrics.OrderByDescending(dm => dm.Date).FirstOrDefaultAsync();

        if (first == null || last == null || first.WeightLbs == null || last.WeightLbs == null)
            return (0, 0, 0);

        return (first.WeightLbs.Value, last.WeightLbs.Value, last.WeightLbs.Value - first.WeightLbs.Value);
    }

    public Task UpdateAsync(DailyMetric metric) {
        _context.DailyMetrics.Update(metric);
        return _context.SaveChangesAsync();
    }

    public async Task<List<HesPhase>> GetAllPhasesAsync() {
        return await _context.HesPhases
            .Include(p => p.Goals)
            .Include(p => p.ExitConditions)
            .OrderBy(p => p.Order)
            .ToListAsync();
    }

    public async Task<HesPhase?> GetCurrentPhaseAsync() {
        return await _context.HesPhases
            .Include(p => p.Goals)
            .FirstOrDefaultAsync(p => p.IsActive);
    }
}
