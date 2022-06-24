using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.WishList.Create
{
    public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, IContractResponse>
    {
        public CreateWishListCommandHandler()
        {
        }

        public async Task<IContractResponse> Handle(CreateWishListCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
