using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;
using WM.CrossCutting.Helper;

namespace WM.Application.Commands.WishLists.Create
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
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }

        public string Link { get; set; }

        public ProductType Status { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
