using HESDashboard.Models;

namespace HESDashboard.Services;

public interface IForecastService {
    Task<List<ForecastResultDTO>> GenerateForecastAsync();
}
