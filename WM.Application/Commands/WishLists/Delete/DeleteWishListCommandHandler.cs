using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Application.Commands.WishLists.Delete
{
    public class DeleteWishListCommandHandler : IRequestHandler<DeleteWishListCommand, IContractResponse>
    {
        private readonly DefaultContext defaultContext;

        public DeleteWishListCommandHandler(DefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }
        public async Task<IContractResponse> Handle(DeleteWishListCommand command, CancellationToken cancellationToken)
        {
            var wishList = await this.defaultContext.WishLists.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            if (wishList is null)
                throw new Exception("Lista não encontrada !");

            this.defaultContext.WishLists.Remove(wishList);

            await this.defaultContext.SaveChangesAsync(cancellationToken);

            return ContractResponse.ValidContractResponse("Lista removida com sucesso !");
        }
    }
}
