namespace HESDashboard.Services.Interfaces;

public interface IExportService<TModel, TExportDto> {
    Task<string> ExportSingleAsync(int id);
    Task<string> ExportRangeAsync(DateOnly from, DateOnly to);
    Task<string> ExportAllAsync();
}
