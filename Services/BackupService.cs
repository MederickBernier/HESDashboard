
using HESDashboard.Data;
using HESDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HESDashboard.Services;

public class BackupService : IBackupService {
    private readonly HesDbContext _context;

    public BackupService(HesDbContext context) => _context = context;
    public async Task<byte[]> GenerateBackupAsJsonAsync() {
        var data = new {
            ExportedAt = DateTime.UtcNow,

            // Existing
            DailyMetrics = await _context.DailyMetrics.ToListAsync(),
            Tags = await _context.Tags.ToListAsync(),
            Goals = await _context.HesGoals.ToListAsync(),
            Thresholds = await _context.Thresholds.ToListAsync(),
            Phases = await _context.HesPhases
                .Include(p => p.Goals)
                .Include(p => p.ExitConditions)
                .ToListAsync(),

            // NEW additions
            Meals = await _context.Meals.ToListAsync(),
            TrainingLogs = await _context.Trainings.ToListAsync(),
        };

        var options = new JsonSerializerOptions {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        string json = JsonSerializer.Serialize(data, options);
        return Encoding.UTF8.GetBytes(json);
    }

}
