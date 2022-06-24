using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;

namespace WM.Context.Default.Entities
{
    public class WishListUser
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid WishListId { get; set; }

        public WishListUserType UserType { get; set; }

        public User User { get; set; }

        public WishList WishList { get; set; }
    }
}
