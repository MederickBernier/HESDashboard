using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HESDashboard.Models;
public class HesGoal {
    public int Id { get; set; }

    [Required]
    public int HesPhaseId { get; set; }

    [ForeignKey("HesPhaseId")]
    public HesPhase? Phase { get; set; }

    [Required]
    [MaxLength(200)]
    public string Description { get; set; }

    [MaxLength(100)]
    public string? BehaviorTrigger { get; set; }

    [MaxLength(100)]
    public string? ConditionKey { get; set; }

    [MaxLength(100)]
    public string? ConditionValue { get; set; }

    public bool IsActive { get; set; } = true;

    public string? Tags { get; set; }
}
