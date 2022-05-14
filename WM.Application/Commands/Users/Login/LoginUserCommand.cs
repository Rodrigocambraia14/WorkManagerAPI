using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.Users.Login
{
    public class LoginUserCommand : IRequest<IContractResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
