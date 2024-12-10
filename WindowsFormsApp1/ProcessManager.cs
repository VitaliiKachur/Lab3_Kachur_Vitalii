using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ProcessManager
{
    public void StartProgram(string programPath)
    {
        Process.Start(programPath);
    }

    public void StopProcess(int processId)
    {
        var process = Process.GetProcessById(processId);
        process.Kill();
    }

    public void ChangeProcessPriority(int processId, ProcessPriorityClass priority)
    {
        var process = Process.GetProcessById(processId);
        process.PriorityClass = priority;
    }

    public List<ProcessInfo> GetProcesses()
    {
        return Process.GetProcesses().Select(p =>
        {
            try
            {
                return new ProcessInfo
                {
                    ProcessId = p.Id,
                    ProcessName = p.ProcessName,
                    MemoryUsage = p.PrivateMemorySize64 / 1024 / 1024,
                    StartTime = p.StartTime.ToString("g"),
                    Priority = p.PriorityClass.ToString(),
                    Threads = p.Threads.Count
                };
            }
            catch
            {
                return null; 
            }
        }).Where(info => info != null).ToList();
    }
}

public class ProcessInfo
{
    public int ProcessId { get; set; }
    public string ProcessName { get; set; }
    public long MemoryUsage { get; set; } 
    public string StartTime { get; set; }
    public string Priority { get; set; }
    public int Threads { get; set; }
}

