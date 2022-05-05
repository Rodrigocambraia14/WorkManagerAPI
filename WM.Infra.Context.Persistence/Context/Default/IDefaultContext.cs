using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Context.Default.Entities;

namespace WM.Infra.Context.Persistence.Context.Default
{
    public interface IDefaultContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserRole> userRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Role> RoleClaims { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<UserLogin> UserLogin { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
