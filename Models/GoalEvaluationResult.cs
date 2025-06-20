using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HESDashboard.Models;

public class GoalEvaluationResult {
    public int Id { get; set; }
    [Required]
    public int HesGoalId { get; set; }
    [ForeignKey("HesGoalId")]
    public HesGoal Goal { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    public bool IsSatisfied { get; set; }
}
