using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IContractResponse>
    {
        public LoginUserCommandHandler()
        {
        }

        public Task<IContractResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
