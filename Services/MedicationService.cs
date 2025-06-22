using HESDashboard.Data;
using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class MedicationService : IMedicationService {
    private readonly HesDbContext _context;

    public MedicationService(HesDbContext context) => _context = context;

    //Medication Catalog Methods
    public async Task AddMedicationAsync(MedicationCatalog medication) {
        _context.MedicationCatalogs.Add(medication);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMedicationAsync(int id) {
        var med = await GetMedicationByIdAsync(id);
        if (med != null) {
            _context.MedicationCatalogs.Remove(med);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<MedicationCatalog?> GetMedicationByIdAsync(int id) {
        return await _context.MedicationCatalogs.FindAsync(id);
    }

    public async Task<List<MedicationCatalog>> GetAllMedicationsAsync() {
        return await _context.MedicationCatalogs.OrderBy(m => m.Name).ToListAsync();
    }

    public async Task UpdateMedicationAsync(MedicationCatalog medication) {
        _context.MedicationCatalogs.Update(medication);
        await _context.SaveChangesAsync();
    }

    // Medication Entries Methods

    public async Task AddEntryAsync(MedicationEntry entry) {
        _context.MedicationEntries.Add(entry);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEntryAsync(int id) {
        var entry = await GetEntryByIdAsync(id);
        if (entry != null) {
            _context.MedicationEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<MedicationEntry>> GetAllEntriesAsync() {
        return await _context.MedicationEntries
            .Include(e => e.Medication)
            .OrderByDescending(e => e.TimeTaken)
            .ToListAsync();
    }

    public async Task<List<MedicationEntry>> GetAllEntriesByDateAsync(DateOnly date) {
        return await _context.MedicationEntries
            .Include(e => e.Medication)
            .Where(e => DateOnly.FromDateTime(e.TimeTaken) == date)
            .OrderByDescending(e => e.TimeTaken)
            .ToListAsync();
    }

    public async Task<MedicationEntry?> GetEntryByIdAsync(int id) {
        return await _context.MedicationEntries
            .Include(e => e.Medication)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task UpdateEntryAsync(MedicationEntry entry) {
        _context.MedicationEntries.Update(entry);
        await _context.SaveChangesAsync();
    }
}
