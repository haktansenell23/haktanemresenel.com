using haktanemresenel.com.core.Dtos;
using haktanemresenel.com.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace haktanemresenel.com.webUI.Controllers
{
    [Route("Admin")]
    public class AdminLoginController : Controller
    {

        private readonly ISessionService _sessionService;
        public AdminLoginController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet("")]
        public IActionResult Index()
      {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginRequestDto loginRequestDto)
        {

            await _sessionService.SetSession(loginRequestDto);

            var result = await _sessionService.GetSession();

            throw new NotImplementedException();
        }
    }
}
