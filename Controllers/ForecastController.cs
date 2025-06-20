using HESDashboard.Enums;
using HESDashboard.Models;
using HESDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers;

[Route("Forecast")]
public class ForecastController : Controller {
    private readonly IForecastService _forecastService;

    public ForecastController(IForecastService forecastService) => _forecastService = forecastService;

    [HttpGet("")]
    public async Task<IActionResult> Index() {
        var forecasts = await _forecastService.GenerateForecastAsync();

        return View(forecasts);
    }
}
