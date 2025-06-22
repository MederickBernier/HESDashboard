using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminPhasesController : Controller {
    private readonly IHesPhaseService _service;

    public AdminPhasesController(IHesPhaseService service) => _service = service;

    public async Task<IActionResult> Index() {
        var phases = await _service.GetAllAsync();
        return View(phases);
    }
    public IActionResult Create() => View(new HesPhase());
    [HttpPost]
    public async Task<IActionResult> Create(HesPhase phase) {
        if (!ModelState.IsValid) return View(phase);
        await _service.AddAsync(phase);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id) {
        var phase = await _service.GetByIdAsync(id);
        if (phase is null) return NotFound();
        return View(phase);
    }
    public async Task<IActionResult> Delete(int id) {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ExitConditions(int phaseId) {
        var phase = await _service.GetByIdAsync(phaseId);
        if (phase == null) return NotFound();

        ViewBag.PhaseName = phase.Name;
        ViewBag.PhaseId = phase.Id;

        var conditions = await _service.GetExitConditionsAsync(phaseId);
        return View(conditions);
    }
    public IActionResult AddExitCondition(int phaseId) {
        return View(new HesPhaseExitCondition { HesPhaseId = phaseId });
    }
    [HttpPost]
    public async Task<IActionResult> AddExitCondition(HesPhaseExitCondition condition) {
        if (!ModelState.IsValid)
            return View(condition);

        await _service.AddExitConditionAsync(condition);
        return RedirectToAction("ExitConditions", new { phaseId = condition.HesPhaseId });
    }
    public async Task<IActionResult> ToggleExitCondition(int id) {
        await _service.ToggleConditionMetAsync(id);
        var condition = await _service.GetExitConditionsAsync(0); // Dummy call to get phase
        var phaseId = (await _service.GetExitConditionsAsync(0)).FirstOrDefault(c => c.Id == id)?.HesPhaseId ?? 0;
        return RedirectToAction("ExitConditions", new { phaseId });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, HesPhase phase) {
        if (id != phase.Id)
            return NotFound();

        if (!ModelState.IsValid) {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors)) {
                Console.WriteLine($"Validation error: {error.ErrorMessage}");
            }
            return View(phase);
        }

        // OPTIONAL: Automatically mark phase as completed if all required exit conditions are met
        if (phase.ExitConditions != null && phase.ExitConditions.All(c => !c.IsRequired || c.IsMet)) {
            phase.IsCompleted = true;
        }

        try {
            await _service.UpdatePhaseWithExitConditionsAsync(phase);
        } catch (Exception ex) {
            ModelState.AddModelError("", $"An error occurred while updating the phase: {ex.Message}");
            return View(phase);
        }

        return RedirectToAction(nameof(Index));
    }
}
