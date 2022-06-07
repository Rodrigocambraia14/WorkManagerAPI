using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;
using WM.CrossCutting.Helper;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IContractResponse>
    {
        private readonly DefaultContext defaultContext;
        private readonly SignInManager<User> signInManager;

        public LoginUserCommandHandler(DefaultContext defaultContext,
                                       SignInManager<User> signInManager)
        {
            this.defaultContext = defaultContext;
            this.signInManager = signInManager;
        }

        public async Task<IContractResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await this.defaultContext.Users.FirstOrDefaultAsync(x => x.Login == command.Login, cancellationToken: cancellationToken);

            if (user is null)
                throw new Exception("Usuário não encontrado !");

            var login = await this.signInManager.PasswordSignInAsync(user, command.Password, false, false);

            if (login.Succeeded)
                return ContractResponse.ValidContractResponse(string.Empty, user);
            else
                throw new Exception("Login ou senha incorretos !");


        }
    }
}
