using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorJwtAuth.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public string GetValue()
        {
            return $"This is simple value {DateTime.Now}.";
        }

        [HttpGet("special"), Authorize]
        public string GetSpecialValue()
        {
            var userName = User.Identity?.Name;
            return $"This is special value {DateTime.Now}. Current user: {userName}";
        }
    }
}
