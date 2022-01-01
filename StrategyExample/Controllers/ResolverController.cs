using Microsoft.AspNetCore.Mvc;
using StrategyExample.Loggers;
using System;

namespace StrategyExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResolverController : ControllerBase
    {
        private readonly Func<EnumLoggerType, ICustomLogger> resolver;

        public ResolverController(Func<EnumLoggerType, ICustomLogger> resolver)
        {
            this.resolver = resolver;
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            return "default";
        }

        [HttpGet("{loggerType}")]
        public ActionResult<string> Get(EnumLoggerType loggerType)
        {
            var l = resolver(loggerType);
            return l.Write();
        }
    }
}
