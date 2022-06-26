using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;

namespace WM.Application.Queries.WishLists.Get
{
    public class GetWishListQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal AchievedMoney { get; set; }

        public Guid UserId { get; set; }

        public List<GetWishListUserResponse> WishListUsers { get; set; }

        public List<GetProductResponse> Products { get; set; }
    }
    
    public class GetProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }

        public string Link { get; set; }

        public ProductType Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Quantity { get; set; }
    }

    public class GetWishListUserResponse
    {
        public WishListUserType UserType { get; set; }

        public GetUserResponse User { get; set; }
    }

    public class GetUserResponse
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string? ImageProfile { get; set; }
    }
}
