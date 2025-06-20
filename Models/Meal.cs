using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;

public class Meal {
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required, MaxLength(50)]
    public string MealType { get; set; } = string.Empty;

    public int? Calories { get; set; }
    public double? ProteinGrams { get; set; }
    public double? CarbsGrams { get; set; }
    public double? FatGrams { get; set; }

    [MaxLength(20)]
    public string? PlanRef { get; set; }

    [MaxLength(200)]
    public string? Substitutions { get; set; }

    [MaxLength(20)]
    public string? Mood { get; set; }

    public int? SatietyBefore { get; set; }
    public int? SatietyAfter { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
    public DateTime TimeLogged { get; set; } = DateTime.Now;
}

