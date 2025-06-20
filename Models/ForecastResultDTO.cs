namespace HESDashboard.Models;

public class ForecastResultDTO {
    public string MetricName { get; set; }
    public double? CurrentValue { get; set; }
    public double? Forecast7Days { get; set; }
    public double? Forecast14Days { get; set; }
    public double? Forecast30Days { get; set; }
    public string AlgorithmUsed { get; set; }
}

