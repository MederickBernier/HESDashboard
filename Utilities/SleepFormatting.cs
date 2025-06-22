namespace HESDashboard.Utilities;

public static class SleepFormatting {
    public static string ToHoursAndMinutes(this TimeSpan? ts) {
        if (!ts.HasValue) return "-";

        int hours = ts.Value.Hours + (ts.Value.Days * 24);
        int minutes = ts.Value.Minutes;

        if (hours == 0)
            return $"{minutes} min";
        if (minutes == 0)
            return $"{hours} hr";

        return $"{hours} hr {minutes} min";
    }
}
