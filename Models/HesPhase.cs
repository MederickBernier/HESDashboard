using HESDashboard.Models;
using System.ComponentModel.DataAnnotations;

namespace HESDashboard.Models;
public class HesPhase {
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public int Order { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<HesGoal> Goals { get; set; } = new List<HesGoal>();
    public ICollection<HesPhaseExitCondition> ExitConditions { get; set; }
    public bool IsCompleted { get; set; } = false;
}
