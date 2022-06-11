using AutoMapper;
using EnumsNET;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;
using WM.CrossCutting.Enums;
using WM.CrossCutting.Helper;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IContractResponse>
    {
        private readonly IDefaultContext defaultContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public RegisterUserCommandHandler(IDefaultContext defaultContext,
                                          IMapper mapper,
                                          UserManager<User> userManager)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IContractResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (await this.defaultContext.Users.AnyAsync(x => x.Email.ToLower() == command.Email.ToLower(), cancellationToken: cancellationToken))
                throw new Exception("Já existe um usuário com este email !");

            if (await this.defaultContext.Users.AnyAsync(x => x.UserName.ToLower() == command.Login.ToLower(), cancellationToken: cancellationToken))
                throw new Exception("Este nome de usuário já está sendo utilizado.");

            var user = this.mapper.Map<User>(command,
                    opt => opt.AfterMap((src, dest) =>
                    {
                        dest.CreatedDate = DateTime.Now;
                        dest.UserName = command.Login;
                        dest.Email = command.Email;
                        dest.NormalizedEmail = command.Email.ToUpper();
                        dest.NormalizedUserName = command.Login.ToUpper();
                    }));

            var result = await this.userManager.CreateAsync(user, command.Password);

            if (result.Succeeded)
            {
                await this.userManager.AddToRoleAsync(user, command.UserType.AsString(EnumFormat.Description));

                return ContractResponse.ValidContractResponse("Conta criada com sucesso !");
            }
            else
                throw new Exception("Não foi possível finalizar a criação de conta, tente novamente mais tarde !");
        }
    }
}
