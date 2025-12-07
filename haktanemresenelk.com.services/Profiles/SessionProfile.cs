using AutoMapper;
using haktanemresenel.com.core.Dtos;
using haktanemresenel.com.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haktanemresenelk.com.services.Profiles
{
    public class SessionProfile:  Profile
    {

        public SessionProfile()
        {
            CreateMap<AdminLoginRequestDto, SessionModel>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));

        }
    }
}
