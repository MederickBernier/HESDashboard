using HESDashboard.Models;

namespace HESDashboard.ViewModels;

public class MedicationEntryFormViewModel {
    public MedicationEntry Entry { get; set; } = new();
    public List<MedicationCatalog> AvailableMedications { get; set; } = new();

    public string? FormTitle { get; set; }
    public string? SubmitButtonText { get; set; }
}
