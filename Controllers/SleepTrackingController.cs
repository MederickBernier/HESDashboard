using HESDashboard.Services.Interfaces;
using HESDashboard.Utilities;
using HESDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HESDashboard.Controllers;
public class SleepTrackingController : Controller {
    private readonly ISleepTrackingService _service;
    public SleepTrackingController(ISleepTrackingService service) => _service = service;

    public async Task<IActionResult> Index() {
        var entries = await _service.GetAllAsync();
        return View(entries);
    }

    public async Task<IActionResult> Details(int id) {
        var entry = await _service.GetByIdAsync(id);
        if (entry == null) return NotFound();
        return View(entry);
    }

    public IActionResult Create() => View(new SleepTrackingEntryFormViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SleepTrackingEntryFormViewModel vm) {
        if (!ModelState.IsValid) return View(vm);
        await _service.AddAsync(vm.ToModel());
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var entry = await _service.GetByIdAsync(id);
        if (entry == null) return NotFound();
        var vm = entry.ToViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SleepTrackingEntryFormViewModel vm) {
        if (!ModelState.IsValid) return View(vm);
        await _service.UpdateAsync(vm.ToModel());
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        var entry = await _service.GetByIdAsync(id);
        if (entry == null) return NotFound();
        return View(entry);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
