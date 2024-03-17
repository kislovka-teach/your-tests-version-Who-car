using System.Text;
using FirstVersion.Abstractions;
using FirstVersion.Configurations;
using FirstVersion.EndPoints;
using FirstVersion.Repositories;
using FirstVersion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"])
            ),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterUserEndpointsGroup();
app.RegisterCarsEndpointsGroup();

app.Run();
