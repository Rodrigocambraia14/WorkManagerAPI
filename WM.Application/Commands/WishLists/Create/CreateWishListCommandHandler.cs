using AutoMapper;
using MediatR;
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

            if(await this.defaultContext.WishLists.AnyAsync(x => x.Name == command.Name && x.WishListUsers.Any(y => y.UserId == command.UserId && y.UserType == WishListUserType.Owner), cancellationToken: cancellationToken))
                throw new Exception("Você já possui uma lista com este nome !");

            var wishList = this.mapper.Map<WishList>(command,
                    opt => opt.AfterMap((src, dest) =>
                    {
                        dest.CreatedDate = DateTime.Now;
                        //dest.Products = this.mapper.Map<List<Product>>(command.Products);
                    }));

            await this.defaultContext.WishLists.AddAsync(wishList, cancellationToken);

            await this.defaultContext.WishListUsers.AddAsync(new WishListUser()
            {
                UserId = command.UserId,
                UserType = WishListUserType.Owner,
                WishListId = wishList.Id
            }, cancellationToken);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Lista criada com sucesso !");
        }
    }
}
