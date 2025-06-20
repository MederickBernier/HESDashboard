using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;

public class DailyMetric {
    public int Id { get; set; }

    [Display(Name = "Date")]
    public DateOnly? Date { get; set; }

    [Display(Name = "Weight (lbs)")]
    public double? WeightLbs { get; set; }

    public double? BMI { get; set; }

    [Display(Name = "Body Fat (%)")]
    public double? BodyFatPercent { get; set; }

    [Display(Name = "Heart Rate (bpm)")]
    public int? HeartRate { get; set; }

    [Display(Name = "Muscle Mass (lbs)")]
    public double? MuscleMassLbs { get; set; }

    [Display(Name = "Basal Metabolic Rate (kcal)")]
    public int? BMRKcal { get; set; }

    [Display(Name = "Water (%)")]
    public double? WaterPercent { get; set; }

    [Display(Name = "Body Fat Mass (lbs)")]
    public double? BodyFatMassLbs { get; set; }

    [Display(Name = "Lean Body Mass (lbs)")]
    public double? LeanBodyMassLbs { get; set; }

    [Display(Name = "Bone Mass (lbs)")]
    public double? BoneMassLbs { get; set; }

    [Display(Name = "Visceral Fat")]
    public int? VisceralFat { get; set; }

    [Display(Name = "Protein (%)")]
    public double? ProteinPercent { get; set; }

    [Display(Name = "Skeletal Muscle Mass (lbs)")]
    public double? SkeletalMuscleMassLbs { get; set; }

    [Display(Name = "Subcutaneous Fat (%)")]
    public double? SubcutaneousFatPercent { get; set; }

    [Display(Name = "Body Age (years)")]
    public int? BodyAgeYears { get; set; }

    [Required, MaxLength(20)]
    [Display(Name = "Body Type")]
    public string BodyType { get; set; } = string.Empty;
}
