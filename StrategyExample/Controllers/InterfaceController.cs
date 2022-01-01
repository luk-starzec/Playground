using Microsoft.AspNetCore.Mvc;
using StrategyExample.Loggers;
using System.Collections.Generic;
using System.Linq;

namespace StrategyExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        private readonly IEnumerable<ICustomLogger> loggers;

        public InterfaceController(IEnumerable<ICustomLogger> loggers)
        {
            this.loggers = loggers;
        }

        [HttpGet("")]
        public ActionResult<string> Get()
        {
            return "default";
        }

        [HttpGet("{loggerType}")]
        public ActionResult<string> Get(EnumLoggerType loggerType)
        {
            var l = loggers.Where(r => r.Logger == loggerType).First();
            return l.Write();
        }

    }
}
