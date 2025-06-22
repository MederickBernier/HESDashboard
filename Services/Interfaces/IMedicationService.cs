using HESDashboard.Models;
using Microsoft.Data.SqlClient.DataClassification;

namespace HESDashboard.Services.Interfaces;

public interface IMedicationService {
    // Catalog
    Task<List<MedicationCatalog>> GetAllMedicationsAsync();
    Task<MedicationCatalog?> GetMedicationByIdAsync(int id);
    Task AddMedicationAsync(MedicationCatalog medication);
    Task UpdateMedicationAsync(MedicationCatalog medication);
    Task DeleteMedicationAsync(int id);

    // Medication Entries
    Task<List<MedicationEntry>> GetAllEntriesAsync();
    Task<List<MedicationEntry>> GetAllEntriesByDateAsync(DateOnly date);
    Task<MedicationEntry?> GetEntryByIdAsync(int id);
    Task AddEntryAsync(MedicationEntry entry);
    Task UpdateEntryAsync(MedicationEntry entry);
    Task DeleteEntryAsync(int id);
}
