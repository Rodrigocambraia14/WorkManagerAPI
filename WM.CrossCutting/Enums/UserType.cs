using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.CrossCutting.Enums
{
    public enum UserType
    {
        [Description("Gestor")]
        Manager = 1,

        [Description("Funcionário")]
        Employee = 2
    }
}
