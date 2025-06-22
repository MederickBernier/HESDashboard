using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers;
public class TrainingController : Controller {
    private readonly ITrainingService _service;
    public TrainingController(ITrainingService service) => _service = service;

    public async Task<IActionResult> Index() {
        var trainings = await _service.GetAllAsync();
        return View(trainings);
    }

    public async Task<IActionResult> Details(int id) {
        var training = await _service.GetByIdAsync(id);
        if (training == null) return NotFound();
        return View(training);
    }

    public IActionResult Create() {
        return View(new Training {
            Date = DateOnly.FromDateTime(DateTime.Today),
            Timeframe = "Morning",
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Training training) {
        if (!ModelState.IsValid) return View(training);
        await _service.AddAsync(training);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var training = await _service.GetByIdAsync(id);
        if (training == null) return NotFound();
        return View(training);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Training training) {
        if (id != training.Id) return NotFound();
        if (!ModelState.IsValid) return View(training);
        await _service.UpdateAsync(training);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id) {
        var training = await _service.GetByIdAsync(id);
        if (training == null) return NotFound();
        return View(training);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
