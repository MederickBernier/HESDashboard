using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.RateLimiting;

namespace HESDashboard.Models;

public class MedicationEntry {
    public int Id { get; set; }

    [Required]
    public int MedicationCatalogId { get; set; }

    [Display(Name = "Time Taken")]
    public DateTime TimeTaken { get; set; } = DateTime.Now;

    [Display(Name = "Dosage Override (optional)")]
    public string? DosageOverride { get; set; }

    [Display(Name = "Taken With Food")]
    public bool WithFood { get; set; } = false;

    [Display(Name = "Additional Notes")]
    public string? Notes { get; set; }

    public MedicationCatalog? Medication { get; set; }
}
