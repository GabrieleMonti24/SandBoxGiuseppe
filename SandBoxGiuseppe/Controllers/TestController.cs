using Microsoft.AspNetCore.Mvc;

namespace SandBoxGiuseppe.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Test1");
                return Ok("Test4");
            }
            catch (Exception ex)
            {
                _logger.LogError("Test1", ex.Message);
                throw;
            }

        }

    }
}