using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Infra.Context.Persistence.Context.Default;

namespace WM.Infra.Context.Persistence.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbContext DbContext { get; set; }

        DefaultContext DefaultContext { get; set; }
    }
}
