using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class SleepTrackingService : ISleepTrackingService {
    private readonly HesDbContext _context;

    public SleepTrackingService(HesDbContext context) => _context = context;
    public async Task AddAsync(SleepTrackingEntry entry) {
        _context.SleepTrackingEntries.Add(entry);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var entry = await _context.SleepTrackingEntries.FindAsync(id);
        if (entry != null) {
            _context.SleepTrackingEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<SleepTrackingEntry>> GetAllAsync() {
        return await _context.SleepTrackingEntries
            .OrderByDescending(e => e.Date)
            .ToListAsync();
    }

    public async Task<SleepTrackingEntry?> GetByIdAsync(int id) {
        return await _context.SleepTrackingEntries.FindAsync(id);
    }

    public async Task UpdateAsync(SleepTrackingEntry entry) {
        _context.SleepTrackingEntries.Update(entry);
        await _context.SaveChangesAsync();
    }
}
