using HESDashboard.DTOs;
using HESDashboard.Models;

namespace HESDashboard.Mappers;

public static class SleepTrackingExportMapper {
    public static SleepTrackingExportDTO ToExportDto(this SleepTrackingEntry entry) {
        return new SleepTrackingExportDTO {
            Date = entry.Date,
            StartOfSleep = entry.StartOfSleep,
            EndOfSleep = entry.EndOfSleep,
            TotalTimeInBedMinutes = entry.TotalTimeInBed?.TotalMinutes,
            ActualSleepMinutes = entry.ActualSleepTime?.TotalMinutes,
            TimeAwakeMinutes = entry.TimeAwake?.TotalMinutes,
            TimeREM_Minutes = entry.TimeREM?.TotalMinutes,
            TimeLight_Minutes = entry.TimeLight?.TotalMinutes,
            TimeDeep_Minutes = entry.TimeDeep?.TotalMinutes,
            PercentAwake = entry.PercentAwake,
            PercentREM = entry.PercentREM,
            PercentLight = entry.PercentLight,
            PercentDeep = entry.PercentDeep,
            LowestBloodOxygen = entry.LowestBloodOxygen,
            HighestSkinTemp = entry.HighestSkinTemp,
            LowestSkinTemp = entry.LowestSkinTemp,
            AvgHeartRate = entry.AvgHeartRate,
            AvgRespiratoryRate = entry.AvgRespiratoryRate
        };
    }
}
