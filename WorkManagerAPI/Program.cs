using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WM.Application.Commands.Users;
using WM.Application.Commands.Users.Login;
using WM.Infra.Context.Persistence.Context.Default;
using WM.Infra.Ioc;
using WorkManagerAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ResolveDependencyInjection.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                });

builder.Services.AddControllers();
builder.Services.AddDbContext<DefaultContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(UserCommandProfile));
builder.Services.AddMediatR(typeof(LoginUserCommand).Assembly);
//builder.Services.AddValidatorsFromAssembly(typeof(LoginUserCommandValidator).Assembly);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSwaggerGen();
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidation<,>));

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseCors("All");
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//LoadSeeds(app).GetAwaiter().GetResult();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();