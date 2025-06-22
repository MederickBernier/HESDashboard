using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class MedicationCatalogController : Controller {
    private readonly IMedicationService _service;
    public MedicationCatalogController(IMedicationService service) => _service = service;

    public async Task<IActionResult> Index() {
        var catalog = await _service.GetAllMedicationsAsync();
        return View(catalog);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MedicationCatalog catalog) {
        if (!ModelState.IsValid) return View(catalog);
        await _service.AddMedicationAsync(catalog);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        if (id == null) return NotFound();
        var med = await _service.GetMedicationByIdAsync(id);
        if (med == null) return NotFound();
        return View(med);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MedicationCatalog catalog) {
        if (id != catalog.Id) return NotFound();
        if (!ModelState.IsValid) return View(catalog);
        await _service.UpdateMedicationAsync(catalog);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        if (id == null) return NotFound();
        var med = await _service.GetMedicationByIdAsync(id);
        if (med == null) return NotFound();
        return View(med);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteMedicationAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
