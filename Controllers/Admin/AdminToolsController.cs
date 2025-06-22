using HESDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminToolsController : Controller {
    private readonly IBackupService _service;
    public AdminToolsController(IBackupService service) => _service = service;

    [HttpGet("Export")]
    public async Task<IActionResult> Export() {
        var jsonBytes = await _service.GenerateBackupAsJsonAsync();
        string fileName = $"HES_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.json";
        return File(jsonBytes, "application/json", fileName);
    }

    public IActionResult Index() => View();
}
