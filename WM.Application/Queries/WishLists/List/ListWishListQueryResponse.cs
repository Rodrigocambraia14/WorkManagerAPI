using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Application.Queries.WishLists.List
{
    public class ListWishListQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal AchievedMoney { get; set; }

        public Guid UserId { get; set; }
    }
}
