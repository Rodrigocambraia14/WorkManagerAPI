using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Infra.Context.Persistence.Context.Default;
using WM.Infra.Context.Persistence.Repositories.Interfaces;

namespace WM.Infra.Context.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DefaultContext context)
        {
            DbContext = context;
            DefaultContext = context;
        }
        public DbContext DbContext { get; set; }
        public DefaultContext DefaultContext { get; set; }
        public void ContextInject(DefaultContext context)
        {
            DbContext = context;
            DefaultContext = context;
        }
    }
}
