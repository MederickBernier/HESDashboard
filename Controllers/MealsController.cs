using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers;
public class MealsController : Controller {
    private readonly IMealService _service;

    public MealsController(IMealService service) => _service = service;

    public async Task<IActionResult> Index() {
        var meals = await _service.GetAllMealsAsync();
        return View(meals);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Meal meal) {
        if (!ModelState.IsValid) return View(meal);

        meal.TimeLogged = DateTime.Now;

        await _service.AddMealAsync(meal);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int id) {
        var meal = await _service.GetMealByIdAsync(id);
        if (meal == null) return NotFound();
        return View(meal);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Meal meal) {
        if (id != meal.Id || !ModelState.IsValid) return View(meal);

        var existing = await _service.GetMealByIdAsync(id);
        if (existing == null) return NotFound();

        // Preserve TimeLogged unless you allow changing it
        meal.TimeLogged = existing.TimeLogged;

        await _service.UpdateMealAsync(meal);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        var meal = await _service.GetMealByIdAsync(id);
        if (meal == null) return NotFound();
        return View(meal);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteMealAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Summary() {
        var summaries = await _service.GetMealDaySummariesAsync();
        return View(summaries);
    }
    [HttpGet]
    public async Task<IActionResult> MealDrift() {
        var meals = await _service.GetTodaysMealsAsync();
        if (meals == null || !meals.Any())
            return Content("No Meals Yet!");

        var lastMealTime = meals
            .OrderByDescending(m => m.TimeLogged)
            .First()
            .TimeLogged;

        return PartialView("_MealDrift", lastMealTime);
    }
}
