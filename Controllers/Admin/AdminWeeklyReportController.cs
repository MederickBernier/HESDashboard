using HESDashboard.Models;
using HESDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminWeeklyReportController : Controller {
    private readonly IWeeklyReportService _service;
    public AdminWeeklyReportController(IWeeklyReportService service) => _service = service;

    public async Task<IActionResult> Index() {
        var reports = await _service.GenerateWeeklyReportsAsync();
        return View(reports);
    }
}
