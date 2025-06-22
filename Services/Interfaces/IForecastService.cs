using HESDashboard.Models;

namespace HESDashboard.Services.Interfaces;

public interface IForecastService {
    Task<List<ForecastResultDTO>> GenerateForecastAsync();
}
