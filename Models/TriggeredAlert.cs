namespace HESDashboard.Models;

public class TriggeredAlert {
    public string RuleName { get; set; }
    public DateTime TriggeredAtUtc { get; set; }
    public string Message { get; set; }
}
