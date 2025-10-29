using haktanemresenel.com.core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace haktanemresenel.com.webUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AdminLogin([FromBody] AdminLoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
