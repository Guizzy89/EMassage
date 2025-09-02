using Microsoft.AspNetCore.Mvc;

namespace EMassage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // Отображает представление /Views/Home/Index.cshtml
        }
    }
}
