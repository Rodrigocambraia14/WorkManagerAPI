using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Application.Queries.WishLists.List
{
    public class ListWishListQueryValidator : AbstractValidator<ListWishListQuery>
    {
        public ListWishListQueryValidator()
        {
        }
    }
}
