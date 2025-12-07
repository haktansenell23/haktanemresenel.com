using AutoMapper;
using haktanemresenel.com.core.Dtos;
using haktanemresenel.com.core.Models;
using haktanemresenel.com.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace haktanemresenelk.com.services.Services
{
    public class SessionService:ISessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public SessionService(IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        private ISession session => _contextAccessor.HttpContext!.Session;

        public async Task SetSession(AdminLoginRequestDto model)
        {
            string jsonModel = JsonSerializer.Serialize(model);

            _mapper.Map<SessionModel>(model);


            byte [] bytes = Encoding.UTF8.GetBytes(jsonModel);
            _contextAccessor.HttpContext!.Session.Set("session", bytes);
        }
        public async Task SetSession<T>(string key, T value) where T : class ,new()
        {
       
            string jsonGenModel =JsonSerializer.Serialize<T>(value);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonGenModel);
            _contextAccessor.HttpContext!.Session.Set(key, bytes);
        }

        public async Task<SessionModel> GetSession()
        {

          string sessionJson= session.GetString("session");

          SessionModel sessionModel=JsonSerializer.Deserialize<SessionModel>(sessionJson);    

          if (sessionModel == null)
                return null;
            
          return sessionModel;

        }
        public async Task<T?> GetSession<T>(string key) 
        {

            string sessionJson = session.GetString(key);

            T sessionModel = JsonSerializer.Deserialize<T>(sessionJson);

            if (sessionModel == null)
                return default;

            return sessionModel;

        }


    }
}
