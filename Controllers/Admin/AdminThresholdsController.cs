using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HESDashboard.Controllers.Admin;
public class AdminThresholdsController : Controller {
    private readonly IHesThresholdService _service;

    public AdminThresholdsController(IHesThresholdService service) => _service = service;
    public async Task<IActionResult> Index() {
        var thresholds = await _service.GetAllAsync();
        return View(thresholds);
    }
    public IActionResult Create() => View(new HesThreshold());
    [HttpPost]
    public async Task<IActionResult> Create(HesThreshold threshold) {
        if (!ModelState.IsValid) return View(threshold);
        await _service.AddAsync(threshold);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id) {
        var threshold = await _service.GetByIdAsync(id);
        if (threshold is null) return NotFound();
        return View(threshold);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(HesThreshold threshold) {
        if (!ModelState.IsValid) return View(threshold);
        await _service.UpdateAsync(threshold);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id) {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
