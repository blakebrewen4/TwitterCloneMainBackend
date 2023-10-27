using Microsoft.AspNetCore.Mvc;

namespace TwitterCloneMainBackend.Controllers
{
    public class Logger : Controller
    {
        private readonly ILogger<Logger> _logger;

        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("This is an informational log message.");
            _logger.LogError("This is an error log message.");
            return View();
        }
    }
}

