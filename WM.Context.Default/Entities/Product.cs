using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;

namespace WM.Context.Default.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }

        public string Link { get; set; }

        public ProductType Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Quantity { get; set; }

        public Guid WishListId { get; set; }

        public WishList WishList { get; set; }
    }
}
