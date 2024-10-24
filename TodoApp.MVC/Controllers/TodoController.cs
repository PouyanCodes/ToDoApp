
using TodoApp.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;
using TodoApp.MVC.Models.TodoVMs;

namespace TodoApp.MVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
      
        public IActionResult TodoList()
        {
            return View();
        }

       
        public IActionResult AddTodo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddTodo(CreateTodoVM todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            if (todo.DeadLine.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("DeadLine", "زمان وارد شده صحیح نمی باشد");
                return View(todo);
            }

            else
            {
                _todoService.CreateTodo(todo);
                return Redirect("TodoList");
            }
        }


        public IActionResult EditTodo(int id)
        {
            var todo = _todoService.GetById(id);
            return View(todo);
        }


        [HttpPost]
        public IActionResult EditTodo(EditTodoVM todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            if (todo.DeadLine.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("DeadLine", "زمان وارد شده صحیح نمی باشد");
                return View(todo);
            }

            else
            {
                _todoService.EditTodo(todo);
                return Redirect("TodoList");
            }
        }


        public IActionResult DeleteTodo(int id)
        {
            _todoService.DeleteTodo(id);
            return View("TodoList");
        }


        public IActionResult CheckedTodo(int id)
        {
            _todoService.CheckedTodo(id);
            return View("TodoList");
        }
    }
}
