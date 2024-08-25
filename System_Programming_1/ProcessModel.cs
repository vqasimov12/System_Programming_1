namespace System_Programming_1;

public class ProcessModel
{
    public int Id { get; set; }
    public string ProcessName { get; set; }
    public string Image { get; set; }
    public double Memory { get; set; }
    public double CpuUsage { get; set; }
    public int ThreadCount { get; set; } 
    public DateTime StartTime { get; set; }
    public int BasePriority { get; set; }
}
