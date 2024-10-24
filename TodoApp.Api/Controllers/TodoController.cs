
using TodoApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Contracts.Persistence;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {   
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            var todoList = _todoRepository.GetAll();
            return Ok(todoList);
        }


        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            var todo = _todoRepository.GetById(id);
            return Ok(todo);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Todo todo) 
        {
            _todoRepository.Add(todo);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Todo todo)
        {
            _todoRepository.Update(todo);
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _todoRepository.Delete(id);
            return NoContent();
        }
    }
}
