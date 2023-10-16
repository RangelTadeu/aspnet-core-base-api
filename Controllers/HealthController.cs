using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_base_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var isHealthy = true;

        if (isHealthy)
        {
            return Ok("Healthy.");
        }
        else
        {
            return StatusCode(500, "Not healthy");
        }
    }
}
