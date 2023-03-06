using SpoopyWebAPI.Models.Enums;

namespace SpoopyWebAPI.Models;

public class SpoopyLogs {
    public int Id { get; set; }
    public string Message { get; set; }
    public LogType Type { get; set; }
}
