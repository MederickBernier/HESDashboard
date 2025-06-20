using HESDashboard.Models;
using HESDashboard.ViewModels;

namespace HESDashboard.Services;

public interface IMealService {
    Task<List<Meal>> GetAllMealsAsync();
    Task<Meal?> GetMealByIdAsync(int id);
    Task AddMealAsync(Meal meal);
    Task UpdateMealAsync(Meal meal);
    Task DeleteMealAsync(int id);
    Task<List<MealDaySummaryViewModel>> GetMealDaySummariesAsync();
    Task<List<Meal>> GetTodaysMealsAsync();

}
