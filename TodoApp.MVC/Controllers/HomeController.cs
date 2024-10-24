using Microsoft.AspNetCore.Mvc;

namespace TodoApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
