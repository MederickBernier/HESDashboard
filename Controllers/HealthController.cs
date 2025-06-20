using HESDashboard.Models;
using HESDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace HESDashboard.Controllers;
public class HealthController : Controller {
    private readonly IHealthService _service;

    public HealthController(IHealthService service) {
        _service = service;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 15) {
        var totalCount = await _service.GetCountAsync();
        var logs = await _service.GetAllAsync(page, pageSize);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        return View(logs);
    }

    public async Task<IActionResult> Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DailyMetric metric) {
        if (!ModelState.IsValid) return View(metric);

        await _service.AddAsync(metric);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) {
        var log = await _service.GetByIdAsync(id);
        if (log == null) return NotFound();
        return View(log);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DailyMetric metric) {
        if (id != metric.Id) return NotFound();

        if (!ModelState.IsValid) return View(metric);

        await _service.UpdateAsync(metric);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) {
        var log = await _service.GetByIdAsync(id);
        if (log == null) return NotFound();
        return View(log);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("health/json")]
    public async Task<IActionResult> AllAsJson() {
        var all = await _service.GetEverythingAsync();
        var json = JsonConvert.SerializeObject(all, Formatting.Indented);
        return Content(json, "application/json");
    }

    [HttpGet("health/download")]
    public async Task<IActionResult> DownloadJson() {
        var all = await _service.GetEverythingAsync();
        var json = JsonConvert.SerializeObject(all, Formatting.Indented);
        var bytes = Encoding.UTF8.GetBytes(json);
        return File(bytes, "application/json", "health_log.json");
    }
    public async Task<IActionResult> Phases() {
        var phases = await _service.GetAllPhasesAsync();
        return View(phases);
    }
}
