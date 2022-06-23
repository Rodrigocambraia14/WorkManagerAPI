using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Context.Default.Entities
{
    public class WishList 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal AchievedMoney { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
