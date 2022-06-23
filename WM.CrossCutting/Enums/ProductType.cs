using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.CrossCutting.Enums
{
    public enum ProductType
    {
        [Description("Adquirido")]
        Purchased = 1,

        [Description("Pendente")]
        Pending = 2
    }
}