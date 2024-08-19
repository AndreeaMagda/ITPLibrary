using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
