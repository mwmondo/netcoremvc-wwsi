using Microsoft.AspNetCore.Mvc;
using TodoCRUD.Core.Interfaces;
using TodoCRUD.Models;

namespace TodoCRUD.Controllers.API
{
    [ApiController]
    [Route("/api/todo")]
    public class TodoAPIController:Controller
    {
        private readonly ITodoRepository _todoRepository;
        public TodoAPIController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get()
        {
            return Ok(_todoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TodoModel>> Get(int id)
        {
            return Ok(_todoRepository.Get(id));
        }

        [HttpPut]
        public IActionResult AddAction(TodoModel todo)
        {
            _todoRepository.Create(todo);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAction(int TodoId)
        {
            _todoRepository.Delete(TodoId);
            return Ok();
        }

        [HttpPatch]
        public IActionResult EditAction(TodoModel todo)
        {
            _todoRepository.Update(todo);
            return Ok();
        }
    }
}
