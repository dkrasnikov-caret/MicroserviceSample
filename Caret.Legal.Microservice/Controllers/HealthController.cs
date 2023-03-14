using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Caret.Legal.WebApplication1.Model;

namespace Caret.Legal.WebApplication1.Controllers;

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


  [HttpGet("heartbeat", Name = "GetHeartBeat")]
  public IActionResult GetHeartBeat()
  {
    return Ok();
  }

  [HttpGet("stats", Name = "GetProcess")]
  public IActionResult GetProcess()
  {
    var currentProcess = Process.GetCurrentProcess();
    return Ok(ProcessView.FromProcess(currentProcess));
  }
}
