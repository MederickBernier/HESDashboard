using HESDashboard.DTOs;
using HESDashboard.Mappers;
using HESDashboard.Models;
using HESDashboard.Services.Interfaces;
using System.Text.Json;

namespace HESDashboard.Services.Exports;

public class SleepExportService : IExportService<SleepTrackingEntry, SleepTrackingExportDTO> {
    private readonly ISleepTrackingService _service;

    // Shared serializer options to reduce repetition and ensure consistency
    private static readonly JsonSerializerOptions _jsonOptions = new() {
        WriteIndented = true
    };

    public SleepExportService(ISleepTrackingService service) => _service = service;

    public async Task<string> ExportAllAsync() {
        var all = await _service.GetAllAsync();
        var dtos = all.Select(x => x.ToExportDto()).ToList();
        return JsonSerializer.Serialize(dtos, _jsonOptions);
    }

    public async Task<string> ExportRangeAsync(DateOnly from, DateOnly to) {
        var all = await _service.GetAllAsync();
        var range = all
            .Where(x => x.Date >= from && x.Date <= to)
            .Select(x => x.ToExportDto())
            .ToList();
        return JsonSerializer.Serialize(range, _jsonOptions);
    }

    public async Task<string> ExportSingleAsync(int id) {
        var entry = await _service.GetByIdAsync(id);
        if (entry == null) {
            // Optional: prepare for future logging
            // logger?.LogWarning($"Sleep entry with ID {id} not found.");
            return "{}";
        }

        var dto = entry.ToExportDto();
        return JsonSerializer.Serialize(dto, _jsonOptions);
    }
}
