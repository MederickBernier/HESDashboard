using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class HesThresholdService : IHesThresholdService {
    private readonly HesDbContext _context;

    public HesThresholdService(HesDbContext context) => _context = context;
    public async Task AddAsync(HesThreshold hesThreshold) {
        _context.Thresholds.Add(hesThreshold);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var threshold = await _context.Thresholds.FindAsync(id);
        if (threshold is not null) {
            _context.Thresholds.Remove(threshold);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<HesThreshold>> GetAllAsync() {
        return await _context.Thresholds.OrderBy(t => t.MetricKey).ToListAsync();
    }

    public async Task<HesThreshold?> GetByIdAsync(int id) {
        return await _context.Thresholds.FindAsync(id);
    }

    public async Task UpdateAsync(HesThreshold hesThreshold) {
        _context.Thresholds.Update(hesThreshold);
        await _context.SaveChangesAsync();
    }
}
