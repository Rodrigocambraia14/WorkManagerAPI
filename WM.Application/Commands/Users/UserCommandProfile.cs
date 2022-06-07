using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Application.Commands.Users.Register;
using WM.Context.Default.Entities;

namespace WM.Application.Commands.Users
{
    public class UserCommandProfile : Profile
    {
        public UserCommandProfile()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}
