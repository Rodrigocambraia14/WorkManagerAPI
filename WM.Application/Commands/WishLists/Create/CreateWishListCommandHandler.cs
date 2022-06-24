using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;
using WM.CrossCutting.Helper;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Application.Commands.WishLists.Create
{
    public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, IContractResponse>
    {
        private readonly DefaultContext defaultContext;
        private readonly IMapper mapper;

        public CreateWishListCommandHandler(DefaultContext defaultContext, IMapper mapper)
        {
            this.defaultContext = defaultContext;
            this.mapper = mapper;
        }

        public async Task<IContractResponse> Handle(CreateWishListCommand command, CancellationToken cancellationToken)
        {
            if (this.defaultContext.WishListUsers.Where(x => x.UserId == command.UserId && x.UserType == WishListUserType.Owner).Count() >= 20)
                throw new Exception("Você alcançou o limite de listas permitidas !");

            return ContractResponse.ValidContractResponse(string.Empty);
        }
    }
}
