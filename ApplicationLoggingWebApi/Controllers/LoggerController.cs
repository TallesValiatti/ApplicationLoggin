using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplicationLoggingWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;
        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _logger.LogTrace("Log information message.");
            _logger.LogDebug("Log information message.");
            _logger.LogInformation("Log information message.");
            _logger.LogWarning("Log warning message.");
            _logger.LogError("Log error message.");
            _logger.LogCritical("Log critical message.");

            return Ok();
        }
    }
}