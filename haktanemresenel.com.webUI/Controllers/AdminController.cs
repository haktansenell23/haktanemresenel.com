using Microsoft.AspNetCore.Mvc;

namespace haktanemresenel.com.webUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
