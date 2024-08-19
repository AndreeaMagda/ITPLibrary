using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
