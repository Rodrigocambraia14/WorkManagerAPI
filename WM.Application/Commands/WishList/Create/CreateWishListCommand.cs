using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.WishList.Create
{
    public class CreateWishListCommand : IRequest<IContractResponse>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal AchievedMoney { get; set; } = 0;

        public List<CreateWishListProductCommand> Products { get; set; }
    }

    public sealed class CreateWishListProductCommand
    {

    }
}
