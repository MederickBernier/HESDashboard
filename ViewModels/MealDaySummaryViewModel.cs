using HESDashboard.Models;
using Microsoft.Identity.Client;

namespace HESDashboard.ViewModels;

public class MealDaySummaryViewModel {
    public DateOnly Date { get; set; }
    public List<Meal> Meals { get; set; } = new();
    public int TotalCalories => Meals.Sum(m => m.Calories ?? 0);
    public string? NotesSummary => string.Join("; ", Meals.Where(m => !string.IsNullOrWhiteSpace(m.Notes)).Select(m => m.Notes));
}
