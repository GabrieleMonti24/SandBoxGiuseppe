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
            return Ok("Test");
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Test2");
        }

        [HttpPost]
        public IActionResult ciao([FromBody] string value)
        {
            return Ok(value);
        }

    }
}