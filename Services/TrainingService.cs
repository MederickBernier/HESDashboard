
using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class TrainingService : ITrainingService {
    private readonly HesDbContext _context;
    public TrainingService(HesDbContext context) => _context = context;
    public async Task AddAsync(Training training) {
        _context.Trainings.Add(training);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        var training = await _context.Trainings.FindAsync(id);
        if (training != null) {
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Training>> GetAllAsync() {
        return await _context.Trainings
            .OrderByDescending(t => t.Date)
            .ToListAsync();
    }

    public async Task<Training?> GetByIdAsync(int id) {
        return await _context.Trainings.FindAsync(id);
    }

    public async Task UpdateAsync(Training training) {
        _context.Trainings.Update(training);
        await _context.SaveChangesAsync();
    }
}
