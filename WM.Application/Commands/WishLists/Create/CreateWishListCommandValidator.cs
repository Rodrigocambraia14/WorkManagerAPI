using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Application.Commands.WishLists.Create
{
    public class CreateWishListCommandValidator : AbstractValidator<CreateWishListCommand>
    {
        public CreateWishListCommandValidator()
        {
        }
    }
}
