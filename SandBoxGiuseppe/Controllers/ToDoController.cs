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
        public IActionResult PostTodo([FromBody] ToDo toDo) 
        {
            try
            {
                _logger.LogInformation("PostToDo");
                toDoService.CreaToDo(toDo);
                return Ok();
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
                toDoService.ModificaToDo(todo);
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
                return new BadRequestResult();
            }
        }

        
        [HttpGet]
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
                return new BadRequestResult();
            }
        }

        
        [HttpGet]
        public IActionResult GetCompletati()
        {
            try
            {
                return toDoService.GetToDoByCompleto();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult GetNonCompletati()
        {
            try
            {
                return toDoService.GetToDoByNoNCompletato();

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]
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
                return new BadRequestResult();
            }


        }


    }
}
