using Microsoft.AspNetCore.Mvc;
using SandBoxGiuseppe.Interfaces;
using SandBoxGiuseppe.Model;

namespace SandBoxGiuseppe.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ToDoController : ControllerBase
    {

        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoService toDoService;

        public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService)
        {
            _logger = logger;
            this.toDoService = toDoService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        /*
            Passare un todoSemplice e creare quello completo nel service (idea di far viaggiare meno informazioni possibili)
         */
        public IActionResult CreaTodo([FromBody] ToDo toDo)
        {
            try
            {
                _logger.LogInformation("PostToDo");
                toDoService.CreaToDo(toDo);
                return Created("Creato con successo!", toDo);
            }
            catch (Exception ex)
            {
                _logger.LogError("PostToDo", ex.Message);
                return new BadRequestResult();
            }
        }

        //Modificare in modo da non passare int id
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
                return NotFound();
            }
        }

        [HttpPost]
        //Da modificare con id
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
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("GetTodo");
                return Ok(toDoService.GetToDo());
            }
            catch (Exception ex)
            {
                _logger.LogError("GetToDO", ex.Message);
                return NotFound();
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetToDo([FromQuery] int id)
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
        //Attenzione !
        public IActionResult GetCompletati()
        {
            try
            {
                List<ToDo> nonCompletati = toDoService.GetToDoByNoNCompletato();


                if (nonCompletati.Count == 0)
                {
                    return NotFound();
                }

                return Ok(nonCompletati);

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
                var todos = toDoService.GetToDoByNoNCompletato();

                if (todos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(todos); //non ho capito

            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteToDo([FromQuery] string deleteWith)
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

        //Delete by id


    }
}
