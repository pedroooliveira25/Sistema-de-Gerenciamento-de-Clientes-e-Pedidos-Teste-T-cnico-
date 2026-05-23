using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Application.Products;
using Application.Services;


using Infrastructure.Data;
using Domain.Entities;

using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Logging (Serilog)

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("./logs/application.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

#endregion

#region Database

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

#endregion

#region Authentication (JWT)

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();

#endregion

#region Application Services (Use Cases)
//controller de Auth 
builder.Services.AddScoped<HashService>();
builder.Services.AddScoped<CreateUser>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//controller de Order 
builder.Services.AddScoped<CreateOrder>();

//controller de Product 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProduct>();
builder.Services.AddScoped<UpdateProduct>();

//controller de Product 
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();




#endregion

var app = builder.Build();

#region Middleware Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();