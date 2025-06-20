using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;

public class Tag {
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Category { get; set; }
}
