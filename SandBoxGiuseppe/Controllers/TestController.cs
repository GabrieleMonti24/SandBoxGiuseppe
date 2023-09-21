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
            //commento
            return Ok("Test2");
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Test2");
        }

        [HttpGet]
        public IActionResult Hello2()
        {
            return Ok("Test3");
        }

        [HttpPost]
        public IActionResult ciao([FromBody] string value)
        {
            return Ok(value);
        }

    }
}