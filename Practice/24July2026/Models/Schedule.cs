namespace _24July2026.Models;

public class Schedule
{
    public int ScheduleID { get; set; }

    public string Subject { get; set; } = string.Empty;

    public string Faculty { get; set; } = string.Empty;

    public string Day { get; set; } = string.Empty;

    public string StartTime { get; set; } = string.Empty;

    public string EndTime { get; set; } = string.Empty;

    public string RoomNo { get; set; } = string.Empty;
}