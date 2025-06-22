using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;

public class MedicationCatalog {
    public int Id { get; set; }

    [Required]
    [Display(Name = "Medication Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Default Dosage(e.g., 500mg)")]
    public string? DefaultDosage { get; set; }

    [Display(Name = "Usual With Food")]
    public bool UsualWithFood { get; set; }

    [Display(Name = "Description / Notes")]
    public string? Notes { get; set; }

    public ICollection<MedicationEntry>? Entries { get; set; }
}
