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
        private readonly IAutomationService _automationService;

        public AutomationController(ILogger<AutomationController> logger, IAutomationService automationService)
        {
            _logger = logger;
            _automationService = automationService;
        }

        [HttpPost]
        public async Task Post()
        {
            await _automationService.RunTests();
        }
    }
}
