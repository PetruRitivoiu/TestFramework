using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFramework.Services;

namespace TestFramework.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomationController : ControllerBase
    {
        private readonly ILogger<AutomationController> _logger;
        private readonly AutomationService _automationService;

        public AutomationController(ILogger<AutomationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task Post()
        {
            await _automationService.RunTests();
            await _automationService.SendMail();
        }
    }
}
