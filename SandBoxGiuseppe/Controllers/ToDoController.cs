using Microsoft.AspNetCore.Mvc;
using SandBoxGiuseppe.Database;
using SandBoxGiuseppe.Interfaces;
using SandBoxGiuseppe.Model;
using SandBoxGiuseppe.Services;

namespace SandBoxGiuseppe.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ToDoController : ControllerBase
    {

        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoService toDoService;

        public ToDoController(ILogger<ToDoController> logger, ToDoService toDoService)
        {
            _logger = logger;
            this.toDoService = toDoService;
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreaTodo([FromBody] ToDo toDo) 
        {
            try
            {
                _logger.LogInformation("PostToDo");
                toDoService.CreaToDo(toDo);
                return Created("Creato con successo!",toDo);
            }
            catch (Exception ex)
            {
                _logger.LogError("PostToDo", ex.Message);
                return new BadRequestResult();
            }
        }
        [HttpPost]
        public IActionResult ModificaTodoById([FromBody] ToDo todo, int id)
        {
            try
            {
                _logger.LogInformation("PostToDoModifica");
                toDoService.ModificaToDo(todo, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("PostToDoModifica", ex.Message);
                return new BadRequestResult();
            }
        }
        [HttpPost]
        public IActionResult CompletaTodo([FromBody] ToDo todo)
        {
            try
            {
                _logger.LogInformation("PostToDo");
                toDoService.CompletaToDo(todo);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("PostToDo", ex.Message);
                return new BadRequestResult();
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll(IToDoService service)
        {
            try
            {
                _logger.LogInformation("GetTodo");
                return Ok(service.GetToDo());
            }
            catch (Exception ex)
            {
                _logger.LogError("GetToDO", ex.Message);
                return NotFound();
            }
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetToDo([FromQuery]int id)
        {
            try
            {
                _logger.LogInformation("GetToDo");
                
                return Ok(toDoService.GetToDoById(id));

            }
            catch (Exception ex)
            {
                _logger.LogError("GetToDoById", ex.Message);
                return NotFound();
            }
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCompletati()
        {
            try
            {
                List<ToDo>nonCompletati =  toDoService.GetToDoByNoNCompletato();

                return (IActionResult)nonCompletati; //non ho capito

            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNonCompletati()
        {
            try
            {
                return (IActionResult)toDoService.GetToDoByNoNCompletato(); //non ho capito

            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteToDo([FromQuery] string deleteWith, ToDoService toDoService)
        {
            try
            {
                toDoService.EliminaToDo(deleteWith);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteToDo", ex.Message);
                return NotFound();
            }


        }


    }
}
