using HESDashboard.Models;
using HESDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminGoalsController : Controller {
    private readonly IHesGoalService _goalService;
    private readonly IHesPhaseService _phaseService;

    public AdminGoalsController(IHesGoalService goalService, IHesPhaseService phaseService) {
        _goalService = goalService;
        _phaseService = phaseService;
    }

    public async Task<IActionResult> Index() {
        var goals = await _goalService.GetAllAsync();
        return View(goals);
    }
    public async Task<IActionResult> Create() {
        ViewBag.Phases = await _phaseService.GetAllAsync();
        return View(new HesGoal());
    }
    [HttpPost]
    public async Task<IActionResult> Create(HesGoal goal) {
        if (!ModelState.IsValid) {
            ViewBag.Phases = await _phaseService.GetAllAsync();
            return View(goal);
        }
        await _goalService.AddAsync(goal);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id) {
        var goal = await _goalService.GetByIdAsync(id);
        if (goal is null) return NotFound();

        ViewBag.Phases = await _phaseService.GetAllAsync();
        return View(goal);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(HesGoal goal) {
        if (!ModelState.IsValid) {
            ViewBag.Phases = await _phaseService.GetAllAsync();
            return View(goal);
        }
        await _goalService.UpdateAsync(goal);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id) {
        await _goalService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
