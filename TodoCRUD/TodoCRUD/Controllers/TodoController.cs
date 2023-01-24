using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoCRUD.Core.Interfaces;
using TodoCRUD.Models;

namespace TodoCRUD.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            return View(_todoRepository.GetAllParents());
        }
        public IActionResult Edit(int id)
        {
            return View(_todoRepository.Get(id));
        }
        public IActionResult Details(int id)
        {
            return View(_todoRepository.Get(id));
        }
        public IActionResult Subtasks(int id)
        {
            ViewBag.TodoIdParent = id;
            return View(_todoRepository.GetAllChildrens(id));
        }
        public IActionResult Add(int TodoIdParent)
        {
            ViewBag.TodoIdParent = TodoIdParent;
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View(_todoRepository.Get(id));
        }

        [HttpPost]
        public IActionResult AddAction(TodoModel todo)
        {
            _todoRepository.Create(todo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAction(int TodoId)
        {
            _todoRepository.Delete(TodoId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditAction(TodoModel todo)
        {
            _todoRepository.Update(todo);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}