using HESDashboard.Data;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using HESDashboard.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Services;

public class MealService : IMealService {
    private readonly HesDbContext _context;
    public MealService(HesDbContext context) => _context = context;
    public async Task AddMealAsync(Meal meal) {
        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMealAsync(int id) {
        var meal = await _context.Meals.FindAsync(id);
        if (meal != null) {
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Meal>> GetAllMealsAsync() {
        return await _context.Meals.OrderByDescending(m => m.Date).ToListAsync();
    }

    public async Task<Meal?> GetMealByIdAsync(int id) {
        return await _context.Meals.FindAsync(id);
    }

    public async Task<List<MealDaySummaryViewModel>> GetMealDaySummariesAsync() {
        var meals = await _context.Meals
            .OrderByDescending(m => m.Date)
            .ToListAsync();

        return meals
            .GroupBy(m => m.Date)
            .Select(g => new MealDaySummaryViewModel {
                Date = g.Key,
                Meals = g.ToList()
            })
            .OrderByDescending(s => s.Date)
            .ToList();
    }

    public async Task UpdateMealAsync(Meal meal) {
        _context.Meals.Update(meal);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Meal>> GetTodaysMealsAsync() {
        var today = DateOnly.FromDateTime(DateTime.Today);
        return await _context.Meals
            .Where(m => m.Date == today)
            .OrderBy(m => m.TimeLogged)
            .ToListAsync();
    }

}
