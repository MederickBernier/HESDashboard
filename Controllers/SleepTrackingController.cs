using HESDashboard.DTOs;
using HESDashboard.Models;
using HESDashboard.Services.Exports;
using HESDashboard.Services.Interfaces;
using HESDashboard.Utilities;
using HESDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HESDashboard.Controllers;
public class SleepTrackingController : Controller {
    private readonly ISleepTrackingService _service;
    private readonly IExportService<SleepTrackingEntry, SleepTrackingExportDTO> _export;
    public SleepTrackingController(
        ISleepTrackingService service,
        IExportService<SleepTrackingEntry, SleepTrackingExportDTO> export) {
        _service = service;
        _export = export;
    }

    public async Task<IActionResult> Index() {
        var entries = await _service.GetAllAsync();
        var viewModels = entries.Select(e => e.ToDisplayViewModel()).ToList();
        return View(viewModels);
    }

    public async Task<IActionResult> Details(int id) {
        Models.SleepTrackingEntry? entry = await _service.GetByIdAsync(id);
        if (entry == null) return NotFound();
        return View(entry.ToViewModel());
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

    public async Task<IActionResult> ExportSingle(int id) {
        var json = await _export.ExportSingleAsync(id);
        return Content(json, "application/json");
    }

    public async Task<IActionResult> ExportRange(DateOnly from, DateOnly to) {
        var json = await _export.ExportRangeAsync(from, to);
        return Content(json, "application/json");
    }

    public async Task<IActionResult> ExportAll() {
        var json = await _export.ExportAllAsync();
        return Content(json, "application/json");
    }
}
