using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HESDashboard.Models;

public class HesPhaseExitCondition {
    public int Id { get; set; }

    [Required]
    public int HesPhaseId { get; set; }

    [ForeignKey("HesPhaseId")]
    [ValidateNever]
    public HesPhase Phase { get; set; }

    [Required]
    [MaxLength(300)]
    public string ConditionDescription { get; set; }

    [MaxLength(100)]
    public string? ConditionKey { get; set; }

    [MaxLength(100)]
    public string? ConditionValue { get; set; }

    public bool IsRequired { get; set; } = true;
    public bool IsMet { get; set; } = false;

}
