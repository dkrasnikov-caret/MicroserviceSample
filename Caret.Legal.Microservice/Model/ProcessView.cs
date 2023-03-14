using System.Diagnostics;

namespace Caret.Legal.Microservice.Model;

public class ProcessView
{
  public long WorkingSet64Mb { get; set; }

  public TimeSpan UpTime { get; set; }

  public static ProcessView FromProcess(Process process)
  {
    process.Refresh();
    return new ProcessView
    {
      UpTime = DateTime.Now - process.StartTime,
      WorkingSet64Mb = process.WorkingSet64 / 1024 / 1024
    };
  }
}
