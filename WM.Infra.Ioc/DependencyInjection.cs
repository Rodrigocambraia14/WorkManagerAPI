using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WM.Application.Commands.Users;
using WM.Application.Commands.Users.Login;
using WM.Context.Default.Entities;
using WM.Infra.Context.Persistence.Context.Default;
using WM.Infra.Context.Persistence.Repositories;
using WM.Infra.Context.Persistence.Repositories.Interfaces;

namespace WM.Infra.Ioc
{
    

    public static class ResolveDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var connect = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<DefaultContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<DefaultContext>()
                .AddDefaultTokenProviders();



            #region Services

            services.AddScoped<IDefaultContext, DefaultContext>();
            #endregion Services

            services.AddAutoMapper(typeof(UserCommandProfile));
            //services.AddValidatorsFromAssembly(typeof(LoginUserCommandValidator).Assembly);
        }
    }
}
