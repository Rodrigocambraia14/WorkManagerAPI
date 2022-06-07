using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<IContractResponse>
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; } = UserType.User;
    }
}
