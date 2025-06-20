using HESDashboard.Data;
using HESDashboard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HESDashboard {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // DB Contexts
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<HesDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // MVC + Razor + Blazor components (in .cshtml)
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddRazorComponents()
                   .AddInteractiveServerComponents(); // This enables <component> in MVC

            // Register custom services
            builder.Services.AddScoped<IHealthService, HealthService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IHesPhaseService, HesPhaseService>();
            builder.Services.AddScoped<IHesGoalService, HesGoalService>();
            builder.Services.AddScoped<IHesThresholdService, HesThresholdService>();
            builder.Services.AddScoped<IWeeklyReportService, WeeklyReportService>();
            builder.Services.AddScoped<IBackupService, BackupService>();
            builder.Services.AddScoped<IMealService, MealService>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            //builder.Services.AddScoped<IForecastEngine, ForecastEngine>(); it's for the engine but not fully ready
            builder.Services.AddScoped<IForecastService, ForecastService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) {
                app.UseMigrationsEndPoint();
            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
