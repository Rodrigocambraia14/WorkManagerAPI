using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.WishLists.Delete
{
    public class DeleteWishListCommand : IRequest<IContractResponse>
    {
        public Guid Id { get; set; }
    }
}
