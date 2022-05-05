using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.User.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IContractResponse>
    {
        public RegisterUserCommandHandler()
        {
        }

        public Task<IContractResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
