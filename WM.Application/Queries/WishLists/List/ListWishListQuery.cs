using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Queries.WishLists.List
{
    public class ListWishListQuery : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }
    }
}
