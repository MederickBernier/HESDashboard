using HESDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard.Data;

public class HesDbContext : DbContext {
    public HesDbContext(DbContextOptions<HesDbContext> options) : base(options) { }

    public DbSet<DailyMetric> DailyMetrics => Set<DailyMetric>();
    public DbSet<Meal> Meals => Set<Meal>();
    public DbSet<Training> Trainings => Set<Training>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<HesPhase> HesPhases => Set<HesPhase>();
    public DbSet<HesGoal> HesGoals => Set<HesGoal>();
    public DbSet<HesThreshold> Thresholds => Set<HesThreshold>();
    public DbSet<GoalEvaluationResult> GoalEvaluationResults => Set<GoalEvaluationResult>();
    public DbSet<HesPhaseExitCondition> HesPhaseExitConditions { get; set; }
    public DbSet<MedicationCatalog> MedicationCatalogs { get; set; }
    public DbSet<MedicationEntry> MedicationEntries { get; set; }
    public DbSet<SleepTrackingEntry> SleepTrackingEntries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // Explicit table name mapping
        modelBuilder.Entity<Training>().ToTable("Trainings");

        // Meal config
        modelBuilder.Entity<Meal>().Property(p => p.MealType).IsUnicode(false);
        modelBuilder.Entity<Meal>().Property(p => p.Notes).IsUnicode(false);

        // Training config
        modelBuilder.Entity<Training>().Property(p => p.Notes).IsUnicode(false);
        modelBuilder.Entity<Training>().Property(p => p.Weather).IsUnicode(false);
        modelBuilder.Entity<Training>().Property(p => p.AvgPace).IsUnicode(false);
        modelBuilder.Entity<Training>().Property(p => p.MaxPace).IsUnicode(false);

        // DailyMetric config
        modelBuilder.Entity<DailyMetric>().Property(p => p.BodyType).IsUnicode(false);

        // HesPhase config
        modelBuilder.Entity<HesPhase>(entity => {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                  .HasMaxLength(100)
                  .IsRequired();
            entity.Property(p => p.Description)
                  .HasMaxLength(500);
            entity.Property(p => p.Order);
            entity.Property(p => p.IsActive);
        });

        // HesGoal config
        modelBuilder.Entity<HesGoal>(entity => {
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Description)
                  .HasMaxLength(200)
                  .IsRequired();
            entity.Property(g => g.BehaviorTrigger)
                  .HasMaxLength(100);
            entity.Property(g => g.ConditionKey)
                  .HasMaxLength(100);
            entity.Property(g => g.ConditionValue)
                  .HasMaxLength(100);
            entity.Property(g => g.Tags);
            entity.Property(g => g.IsActive);
            entity.HasOne(g => g.Phase)
                  .WithMany(p => p.Goals)
                  .HasForeignKey(g => g.HesPhaseId);
        });

        // GoalEvaluationResult config
        modelBuilder.Entity<GoalEvaluationResult>(entity => {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Goal)
                  .WithMany()
                  .HasForeignKey(e => e.HesGoalId);
            entity.HasIndex(e => new { e.HesGoalId, e.Date }).IsUnique(); // Prevent duplicates
        });
    }
}
