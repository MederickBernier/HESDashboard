using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using HESDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HESDashboard.Controllers;
public class MedicationController : Controller {
    private readonly IMedicationService _service;
    public MedicationController(IMedicationService service) => _service = service;

    public async Task<IActionResult> Index() {
        var entries = await _service.GetAllEntriesAsync();
        return View(entries);
    }

    public async Task<IActionResult> Create() {
        var viewModel = new MedicationEntryFormViewModel {
            AvailableMedications = await _service.GetAllMedicationsAsync(),
            FormTitle = "Log New Medication",
            SubmitButtonText = "💾 Log Entry"
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MedicationEntryFormViewModel vm) {
        if (!ModelState.IsValid) {
            vm.AvailableMedications = await _service.GetAllMedicationsAsync();
            vm.FormTitle = "Log New Medication";
            vm.SubmitButtonText = "💾 Log Entry";
            return View(vm);
        }

        await _service.AddEntryAsync(vm.Entry);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var entry = await _service.GetEntryByIdAsync(id);
        if (entry == null) return NotFound();

        var viewModel = new MedicationEntryFormViewModel {
            Entry = entry,
            AvailableMedications = await _service.GetAllMedicationsAsync(),
            FormTitle = "Edit Medication Entry",
            SubmitButtonText = "✏️ Update Entry"
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MedicationEntryFormViewModel vm) {
        if (id != vm.Entry.Id) return NotFound();

        if (!ModelState.IsValid) {
            vm.AvailableMedications = await _service.GetAllMedicationsAsync();
            vm.FormTitle = "Edit Medication Entry";
            vm.SubmitButtonText = "✏️ Update Entry";
            return View(vm);
        }

        await _service.UpdateEntryAsync(vm.Entry);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        var entry = await _service.GetEntryByIdAsync(id);
        if (entry == null) return NotFound();
        return View(entry);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteEntryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
