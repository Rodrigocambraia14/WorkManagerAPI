using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Application.Commands.WishLists.Create;
using WM.Context.Default.Entities;

namespace WM.Application.Commands.WishLists
{
    public class WishListProfile : Profile
    {
        public WishListProfile()
        {
            CreateMap<CreateWishListCommand, WishList>();
        }
    }
}
