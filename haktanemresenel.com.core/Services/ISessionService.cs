using haktanemresenel.com.core.Dtos;
using haktanemresenel.com.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenel.com.core.Services
{
    public interface ISessionService
    {
         Task SetSession(AdminLoginRequestDto model);
         Task SetSession<T>(string key, T value) where T : class, new();
         Task<SessionModel> GetSession();
         Task<T?> GetSession<T>(string key);
    }
}
