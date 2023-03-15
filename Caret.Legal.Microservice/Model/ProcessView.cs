using System.Diagnostics;
using JetBrains.Annotations;

namespace Caret.Legal.Microservice.Model;

/// <summary>
/// Process view type.
/// </summary>
[PublicAPI]
public class ProcessView
{
  /// <summary>
  /// Gets or sets the working set64 mb.
  /// </summary>
  /// <value>
  /// The working set64 mb.
  /// </value>
  public long WorkingSet64Mb { get; set; }

  /// <summary>
  /// Gets or sets up time.
  /// </summary>
  /// <value>
  /// Up time.
  /// </value>
  public TimeSpan UpTime { get; set; }

  /// <summary>
  /// Get process view the process.
  /// </summary>
  /// <param name="process">The process.</param>
  /// <returns></returns>
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
