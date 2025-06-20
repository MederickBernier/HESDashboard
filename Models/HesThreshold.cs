using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;

public class HesThreshold {
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string MetricKey { get; set; }
    public double? MinValue { get; set; }
    public double? MaxValue { get; set; }
    [MaxLength(300)]
    public string? AlertMessage { get; set; }
    public bool IsActive { get; set; } = true;
}
