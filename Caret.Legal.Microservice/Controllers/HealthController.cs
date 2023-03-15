using System.Diagnostics;
using Caret.Legal.Microservice.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caret.Legal.Microservice.Controllers;

/// <summary>
/// Health controller.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[AllowAnonymous]
[Route("health")]
public class HealthController : ControllerBase
{
  private readonly ILogger<HealthController> _logger;

  public HealthController(ILogger<HealthController> logger)
  {
    _logger = logger;
  }


  /// <summary>
  /// Gets the heart beat.
  /// </summary>
  /// <returns></returns>
  [HttpGet("heartbeat", Name = "GetHeartBeat")]
  public IActionResult GetHeartBeat()
  {
    return Ok();
  }

  /// <summary>
  /// Gets the process.
  /// </summary>
  /// <returns></returns>
  [HttpGet("stats", Name = "GetProcess")]
  public IActionResult GetProcess()
  {
    var currentProcess = Process.GetCurrentProcess();
    return Ok(ProcessView.FromProcess(currentProcess));
  }
}
