using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.CrossCutting.Enums
{
    public enum WishListUserType
    {
        [Description("Proprietário")]
        Owner = 1,

        [Description("Convidado")]
        Guest = 2
    }
}
