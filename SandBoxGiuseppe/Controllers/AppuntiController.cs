using Microsoft.AspNetCore.Mvc;
using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AppuntiController : ControllerBase
    {

        private readonly ILogger<AppuntiController> _logger;

        public AppuntiController(ILogger<AppuntiController> logger)
        {
            _logger = logger;
        }

        //aggiungere un appunto
        [HttpPost]
        public IActionResult PostAppunto([FromBody] Appunti appunto)
        {
            try
            {
                _logger.LogInformation("PostAppunto");
                AppuntiStoreStatic.appunti.Add(appunto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("PostAppunto", ex.Message);
                return new BadRequestResult();
            }
        }

        //Ottieni tutti gli appunti
        [HttpGet]
        public IActionResult GetAppunti()
        {
            try
            {
                _logger.LogInformation("GetAppunti");
                return Ok(AppuntiStoreStatic.appunti);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAppunti", ex.Message);
                return new BadRequestResult();
            }
        }

        //Ottieni un appunto per titolo
        [HttpGet]
        public IActionResult GetAppunto([FromQuery] string stringa)
        {
            try
            {
                _logger.LogInformation("GetAppunto");
                var appunto = AppuntiStoreStatic.appunti.Where(x => x.Titolo.Contains(stringa)).ToList();
                return Ok(appunto);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetAppunto", ex.Message);
                return new BadRequestResult();
            }
        }

        //Ottieni tutti gli appunti semplificati
        [HttpGet]
        public IActionResult GetAppuntiSemplice()
        {
            try
            {
                List<AppuntiSemplice> appuntiSemplici = new();

                appuntiSemplici = AppuntiStoreStatic.appunti
                    .Select(x => new AppuntiSemplice { Titolo = "Titolo - " + x.Titolo })
                    .ToList();

                return Ok(appuntiSemplici);

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        public IActionResult DeleteAppunto([FromQuery] string stringa)
        {
            try
            {

                AppuntiStoreStatic.appunti.RemoveAll(x => x.Titolo.Contains(stringa));
                return Ok();


            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteAppunto", ex.Message);
                return new BadRequestResult();
            }


        }


    }
}
