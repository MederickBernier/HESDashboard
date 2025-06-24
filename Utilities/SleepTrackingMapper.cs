using HESDashboard.Models;
using HESDashboard.ViewModels;

namespace HESDashboard.Utilities;

public static class SleepTrackingMapper {
    public static SleepTrackingEntry ToModel(this SleepTrackingEntryFormViewModel vm) {
        return new SleepTrackingEntry {
            Id = vm.Id ?? 0,
            Date = vm.Date,
            StartOfSleep = vm.StartOfSleep,
            EndOfSleep = vm.EndOfSleep,
            TotalTimeInBed = FromHrsMins(vm.TotalTimeInBed_Hours, vm.TotalTimeInBed_Minutes),
            ActualSleepTime = FromHrsMins(vm.ActualSleep_Hours, vm.ActualSleep_Minutes),
            TimeAwake = FromHrsMins(vm.TimeAwake_Hours, vm.TimeAwake_Minutes),
            TimeREM = FromHrsMins(vm.TimeREM_Hours, vm.TimeREM_Minutes),
            TimeLight = FromHrsMins(vm.TimeLight_Hours, vm.TimeLight_Minutes),
            TimeDeep = FromHrsMins(vm.TimeDeep_Hours, vm.TimeDeep_Minutes),
            PercentAwake = vm.PercentAwake,
            PercentREM = vm.PercentREM,
            PercentLight = vm.PercentLight,
            PercentDeep = vm.PercentDeep,
            LowestBloodOxygen = vm.LowestBloodOxygen,
            HighestSkinTemp = vm.HighestSkinTemp,
            LowestSkinTemp = vm.LowestSkinTemp,
            AvgHeartRate = vm.AvgHeartRate,
            AvgRespiratoryRate = vm.AvgRespiratoryRate
        };
    }

    public static SleepTrackingEntryFormViewModel ToViewModel(this SleepTrackingEntry entry) {
        return new SleepTrackingEntryFormViewModel {
            Id = entry.Id,
            Date = entry.Date,
            StartOfSleep = entry.StartOfSleep,
            EndOfSleep = entry.EndOfSleep,
            TotalTimeInBed_Hours = entry.TotalTimeInBed?.Hours,
            TotalTimeInBed_Minutes = entry.TotalTimeInBed?.Minutes,
            ActualSleep_Hours = entry.ActualSleepTime?.Hours,
            ActualSleep_Minutes = entry.ActualSleepTime?.Minutes,
            TimeAwake_Hours = entry.TimeAwake?.Hours,
            TimeAwake_Minutes = entry.TimeAwake?.Minutes,
            TimeREM_Hours = entry.TimeREM?.Hours,
            TimeREM_Minutes = entry.TimeREM?.Minutes,
            TimeLight_Hours = entry.TimeLight?.Hours,
            TimeLight_Minutes = entry.TimeLight?.Minutes,
            TimeDeep_Hours = entry.TimeDeep?.Hours,
            TimeDeep_Minutes = entry.TimeDeep?.Minutes,
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
    public static SleepTrackingEntryViewModel ToDisplayViewModel(this SleepTrackingEntry entry) {
        return new SleepTrackingEntryViewModel {
            Id = entry.Id,
            Date = entry.Date,
            TotalTimeInBedMinutes = (int?)entry.TotalTimeInBed?.TotalMinutes,
            ActualSleepMinutes = (int?)entry.ActualSleepTime?.TotalMinutes,
            PercentAwake = entry.PercentAwake,
            PercentREM = entry.PercentREM,
            PercentLight = entry.PercentLight,
            PercentDeep = entry.PercentDeep
        };
    }

    private static TimeSpan? FromHrsMins(int? hrs, int? mins) {
        if (hrs == null && mins == null)
            return null;
        return TimeSpan.FromMinutes((hrs ?? 0) * 60 + (mins ?? 0));
    }

}
