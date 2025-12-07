using haktanemresenel.com.core.Dtos;
using haktanemresenel.com.core.Services;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace haktanemresenelk.com.services.Services
{
    public class AdminService
    {
        private readonly ISessionService _sessionService;   
        private readonly IHttpContextAccessor _contextAccessor; 


        public AdminService(ISessionService sessionService, IHttpContextAccessor contextAccessor)
        {
            _sessionService = sessionService;   
            _contextAccessor = contextAccessor;
        }




        public async Task<bool>AdminLogin(AdminLoginRequestDto model)
        {
            int? tryCount = await _sessionService.GetSession<int>("tryCount");

            if (tryCount > 5)
                return false;

            bool isLoggable = false;





            if (!isLoggable) {

                if (tryCount == null)
                    tryCount = 0;

                string userIpAddress = _contextAccessor.HttpContext!.Connection!.RemoteIpAddress!.ToString();



                return isLoggable;
            }

            return isLoggable;
        }

    }
}
